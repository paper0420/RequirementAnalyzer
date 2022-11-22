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
    public class Testcase
    {
        internal static Testcase? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var id = reader.GetStringOrNull(header.GetColumnIndex("Test Case ID"))?.ToString();

            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            var result = new Testcase();

            result.ID = id;
            result.Objective = reader.GetStringOrNull(header.GetColumnIndex("Test objective"));
            var klhIDs = reader.GetStringOrNull(header.GetColumnIndex("KLH ID"))?
                .ToString()?
                .Split('\n') ?? new string[0];
            var tsrIDs = reader.GetStringOrNull(header.GetColumnIndex("TSR ID"))?
                .ToString()?
                .Split('\n') ?? new string[0];
            var syrIDs = reader.GetStringOrNull(header.GetColumnIndex("SYR ID"))?
                .ToString()?
                .Split('\n') ?? new string[0];

            var carLines = reader.GetStringOrNull(header.GetColumnIndex("Available Car lines"))?
               .ToString()?
               .Split('\n') ?? new string[0];

            result.KLHID = klhIDs.Where(t => t != null).ToList();
            result.TSRID = tsrIDs.Where(t => t != null).ToList();
            result.SYRID = syrIDs.Where(t => t != null).ToList();
            result.CarLines = carLines.Where(t => t != null).ToList();




            return result;
        }

        public List<string> REQID { get; set; } = new List<string> { };
        public List<string> KLHID { get; set; } = new List<string> { };
        public List<string> ICSID { get; set; } = new List<string> { };
        public List<string> TSRID { get; set; } = new List<string> { };
        public List<string> SYRID { get; set; } = new List<string> { };
        public string Objective { get; set; }
        public List<string> CarLines { get; set; } = new List<string> { };
        public string FusaType { get; set; }
        public string Group { get; set; }
        public string ID { get; set; }
        public string RelatedTSRID { get; set; }
        public string SafetyGoal { get; set; }
        public List<string> SubIDs { get; set; }
        public string FunctionCatagory { get; set; }
        public string ErrorFactor { get; set; }


    }
}
