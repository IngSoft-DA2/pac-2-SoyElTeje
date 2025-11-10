using IBusinessLogic;
using IImporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BusinessLogic
{
    public class ImporterLogic : IImporterLogic
    {
        private readonly string _importersPath;

        public ImporterLogic()
        {
            _importersPath = Path.Combine(Directory.GetCurrentDirectory(), "reflection");
        }

        public List<string> GetDllNamesWithImporters()
        {
            List<string> dllNames = new List<string>();

            if (!Directory.Exists(_importersPath))
            {
                return dllNames;
            }

            string[] filePaths = Directory.GetFiles(_importersPath, "*.dll");

            foreach (string filePath in filePaths)
            {
                try
                {
                    if (HasImporterInterface(filePath))
                    {
                        string fileName = Path.GetFileName(filePath);
                        dllNames.Add(fileName);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return dllNames;
        }

        private bool HasImporterInterface(string dllPath)
        {
            try
            {
                FileInfo dllFile = new FileInfo(dllPath);
                Assembly assembly = Assembly.LoadFile(dllFile.FullName);
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (ImplementsRequiredInterface(type))
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        private bool ImplementsRequiredInterface(Type type)
        {
            return typeof(ImporterInterface).IsAssignableFrom(type) 
                   && !type.IsInterface 
                   && type.IsPublic 
                   && !type.IsAbstract;
        }
    }
}

