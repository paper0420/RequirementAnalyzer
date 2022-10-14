using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                ?.ToString()
                ?.Split('\n')?.ToList() ;

            if (id == null)
            {
                return null;
            }

            var result = new ENG9Testcase();

            result.IDs = id;
            var tsrID = reader.GetStringOrNull(header.GetColumnIndex("TSR ID"))?.ToString()?.Split('\n')?.ToList();
            var syrID= reader.GetStringOrNull(header.GetColumnIndex("SYR ID"))?.ToString()?.Split('\n') ?.ToList();
            var klhID = reader.GetStringOrNull(header.GetColumnIndex("KLH ID"))?.ToString()?.Split('\n') ?.ToList();
            var icsID = reader.GetStringOrNull(header.GetColumnIndex("ICS ID"))?.ToString()?.Split('\n') ?.ToList();


            if (tsrID != null)
                result.REQID.AddRange(tsrID);
            
            if (syrID != null)
                result.REQID.AddRange(syrID);

            if (klhID != null)
                result.REQID.AddRange(klhID);

            if (icsID != null)
                result.REQID.AddRange(icsID);

            //result.Objective = reader.GetStringOrNull(8)?.ToString();

            return result;
        }

        public List<string> IDs { get; set; }
        public List<string> REQID { get; set; } = new List<string> { };
        public List<string> KLHID { get; set; }
        public List<string> ICSID { get; set; }
        public List<string> TSRID { get; set; }
        public List<string> SYRID { get; set; }
        public List<string> Objective { get; set; }

    }
}
