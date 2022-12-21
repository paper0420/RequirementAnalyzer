using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class RTM_EPIC_SYR
    {
        internal static RTM_EPIC_SYR? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var result = new RTM_EPIC_SYR();
            result.CCUID = reader.GetValue(11)?.ToString();
            result.SYRID = reader.GetValue(1)?.ToString();
            result.ObjectStatus = reader.GetValue(5)?.ToString();
            result.PanaStatus = reader.GetValue(6)?.ToString();

            return result;
        }
        public string? CCUID { get; set; }
        public string? SYRID { get; set; }
        public string? ObjectStatus { get; set; }
        public string? PanaStatus { get; set; } 


    }
}
