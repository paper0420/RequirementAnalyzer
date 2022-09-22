using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class TSR
    {
        internal static TSR? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var result = new TSR();
            result.ID = reader.GetStringOrNull(header.GetColumnIndex("A_TSR_ID"))?.ToString().Trim();
            result.Objective = reader.GetStringOrNull(header.GetColumnIndex("Requirements"))?.ToString();

            return result;
        }
        public string? ID { get; set; }
        public string Objective { get; set; }


    }
}
