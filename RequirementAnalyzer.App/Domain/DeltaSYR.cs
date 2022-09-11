using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class DeltaSYR
    {
        internal static DeltaSYR? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var result = new DeltaSYR();
            result.ObjectIdentifier = reader.GetValue(header.GetColumnIndex("Object Identifier"))?.ToString();
            result.Objective = reader.GetValue(header.GetColumnIndex("Requirements"))?.ToString();


            return result;
        }
        public string? ObjectIdentifier { get; set; }
        public string? SYRID { get; set; }
        public string Objective { get; set; }


    }
}
