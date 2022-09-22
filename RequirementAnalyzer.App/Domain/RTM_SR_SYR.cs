using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class RTM_SR_SYR
    {
        internal static RTM_SR_SYR? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var result = new RTM_SR_SYR();
            result.SRID = reader.GetStringOrNull(header.GetColumnIndex("SR_ID"))?.ToString().Trim();
            result.SYRID = reader.GetStringOrNull(header.GetColumnIndex("SYR_ID"))?.ToString();

            return result;
        }
        public string? SRID { get; set; }
        public string SYRID { get; set; }


    }
}
