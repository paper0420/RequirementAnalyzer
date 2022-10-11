using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class ENG9Testcase
    {
        internal static ENG9Testcase? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var id = reader.GetStringOrNull(header.GetColumnIndex("Test Case ID"))
                .ToString()?
                .Split('\n') ?? new string[0];

            if (id.Length < 0)
            {
                return null;
            }

            var result = new ENG9Testcase();

            result.IDs = id;
            result.TSRID = reader.GetStringOrNull(header.GetColumnIndex("TSR ID"))?.ToString();
            result.SYRID = reader.GetStringOrNull(header.GetColumnIndex("SYR ID"))?.ToString();
            result.KLHID = reader.GetStringOrNull(header.GetColumnIndex("KLH ID"))?.ToString();
            result.ICSID = reader.GetStringOrNull(header.GetColumnIndex("ICS ID"))?.ToString();


            //result.Objective = reader.GetStringOrNull(8)?.ToString();

            return result;
        }

        public string[] IDs { get; set; }
        public string REQID { get; set; }
        public string KLHID { get; set; }
        public string ICSID { get; set; }
        public string TSRID { get; set; }
        public string SYRID { get; set; }
        public string Objective { get; set; }

    }
}
