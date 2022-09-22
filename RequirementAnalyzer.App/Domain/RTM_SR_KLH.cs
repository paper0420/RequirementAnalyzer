using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class RTM_SR_KLH
    {
        internal static RTM_SR_KLH? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var result = new RTM_SR_KLH();
            result.SRID = reader.GetValue(0)?.ToString().Trim();
            result.KLHID = reader.GetValue(1)?.ToString();

            return result;
        }
        public string? SRID { get; set; }
        public string KLHID { get; set; }


    }
}
