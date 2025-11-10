using IImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleImporter
{
    public class XMLImporter : ImporterInterface
    {
        public string GetName()
        {
            return "XML Importer";
        }
    }
}
