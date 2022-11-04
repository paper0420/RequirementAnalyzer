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
    public class ENG9Testcase
    {
        internal static ENG9Testcase? CreateOrNull(IExcelDataReader reader, Header header, string carLine)
        {
            var id = reader.GetStringOrNull(header.GetColumnIndex("Test Case ID"))?
                .ToString()?
                .Trim()
                .Replace(" ","")
                .Split('\n','\r')?.ToList();

            if (id == null)
            {
                return null;
            }

            var result = new ENG9Testcase();

            result.IDs = id;
            var tsrID = reader.GetStringOrNull(header.GetColumnIndex("TSR ID"))?.ToString()?
                .Trim()
                .Split('\n')?
                .ToList();
            var syrID= reader.GetStringOrNull(header.GetColumnIndex("SYR ID"))?.ToString()?
                .Trim()
                .Replace("#","")
                .Replace(" ","")
                .Replace(",","\n")
                .Split('\n')?
                .ToList();
         
            var klhID = reader.GetStringOrNull(header.GetColumnIndex("KLH ID"))?.ToString()?
                .Replace("\r", "")
                .Replace(" ", "")
                .Trim()
                .Replace(",","\n").Split('\n') ?.ToList();
            var icsID = reader.GetStringOrNull(header.GetColumnIndex("ICS ID"))?.ToString()?
                .Trim()
                .Split('\n') ?.ToList();


            if (tsrID != null)
                result.REQID.AddRange(tsrID);
            
            if (syrID != null)
                result.REQID.AddRange(syrID);

            if (klhID != null)
                result.REQID.AddRange(klhID);

            if (icsID != null)
                result.REQID.AddRange(icsID);

            result.CarLines.Add(carLine);

            result.RelatedTSRID = reader.GetStringOrNull(header.GetColumnIndex("Related TSR/SM/Sequence Chart ID"))?.ToString();
            result.SafetyGoal = reader.GetStringOrNull(header.GetColumnIndex("Safety Goal"))?.ToString();
            result.SubIDs = reader.GetStringOrNull(header.GetColumnIndex("Test ID"))?.ToString()?
                   .Trim()
                   .Split('\n')?
                   .ToList();

            result.FunctionCatagory = reader.GetStringOrNull(header.GetColumnIndex("Categories"))?.ToString();
            result.ErrorFactor = reader.GetStringOrNull(header.GetColumnIndex("Error Factor"))?.ToString();

            return result;
        }


        public List<string> IDs { get; set; }
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
