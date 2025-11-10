using IImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleImporter
{
    public class CSVImporter : ImporterInterface
    {
        public string GetName()
        {
            return "CSV Importer";
        }
    }
}
