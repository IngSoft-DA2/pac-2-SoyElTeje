using IImporter;
using System.Collections.Generic;

namespace IBusinessLogic
{
    public interface IImporterLogic
    {
        List<string> GetDllNamesWithImporters();
    }
}

