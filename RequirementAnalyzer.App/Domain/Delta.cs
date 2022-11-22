using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class Delta
    {
        internal static Delta? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var result = new Delta();
            result.ObjectIdentifier = reader.GetStringOrNull(header.GetColumnIndex("Object Identifier"))?.ToString();
            result.Objective = reader.GetStringOrNull(header.GetColumnIndex("Requirements"))?.ToString();
            result.TSRID = reader.GetStringOrNull(header.GetColumnIndex("A_TSR_ID"))?.ToString();



            return result;
        }
        public string? ObjectIdentifier { get; set; }
        public string? SYRID { get; set; }
        public string? TSRID { get; set; }
        public string Objective { get; set; }


    }
}
