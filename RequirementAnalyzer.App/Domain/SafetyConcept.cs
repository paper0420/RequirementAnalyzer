using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class SafetyConcept
    {
        internal static SafetyConcept? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var result = new SafetyConcept();
            result.ObjectIdentifier = reader.GetValue(header.GetColumnIndex("ID"))?.ToString();
            result.Objective = reader.GetValue(header.GetColumnIndex("Safety Goals"))?.ToString();
            result.SCID = reader.GetValue(header.GetColumnIndex("A_FuSa"))?.ToString().Trim();

            var klhIDs = reader.GetValue(header.GetColumnIndex("KLH"))?
                .ToString()?
                .Split('\n') ?? new string[0];

            var requirementIds = new List<string>();

            foreach (var klhID in klhIDs)
            {
                if (!String.IsNullOrWhiteSpace(klhID))
                {
                    requirementIds.Add(klhID);
                }

            }

            result.RequirementIDs = requirementIds;

            var tsrIDs = reader.GetValue(header.GetColumnIndex("TSR"))?
              .ToString()?
              .Split('\n') ?? new string[0];

            var tsrReqIds = new List<string>();

            foreach (var tsrID in tsrIDs)
            {
                if (!String.IsNullOrWhiteSpace(tsrID))
                {
                    tsrReqIds.Add(tsrID);
                }
                
            }

            result.TSRRequirementIDs = tsrReqIds;


            return result;
        }



        public List<string> RequirementIDs { get; set; }
        public string? SCID { get; set; }
        public string? Objective { get; set; }
        public string? ObjectIdentifier { get; set; }
        public List<string> TSRRequirementIDs { get; set; }
    }
}
