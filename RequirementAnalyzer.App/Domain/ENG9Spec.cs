using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class ENG9Spec
    {
        internal static ENG9Spec? CreateOrNull(IExcelDataReader reader, Header header, string carLine)
        {
            var id = reader.GetStringOrNull(header.GetColumnIndex("Test Case ID"))?.ToString();

            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            var result = new ENG9Spec();

            result.ID = id;
            result.Objective = reader.GetStringOrNull(header.GetColumnIndex("Objective"))?.ToString();

            return result;
        }


        public string Objective { get; set; }
        public string ID { get; set; }


    }
}
