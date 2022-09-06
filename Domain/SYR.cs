using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class SYR
    {
        internal static SYR? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var result = new SYR();
            result.ObjectIdentifier = reader.GetValue(header.GetColumnIndex("ID"))?.ToString();
            result.A_ObjectType = reader.GetValue(header.GetColumnIndex("A_Object Type"))?.ToString();
            var id = reader.GetValue(header.GetColumnIndex("A_SYR-ID"))?.ToString().Trim();

            result.ID = id;
            result.Objective = reader.GetString(header.GetColumnIndex("Objective"));
            var idsAsString = reader.GetValue(header.GetColumnIndex("Object ID from Original"))?
                .ToString()?
                .Split('\n') ?? new string[0];

            var requirementIds = new List<string>();

            foreach (var idAsString in idsAsString)
            {
                requirementIds.Add(idAsString);
            }

            result.RequirementIDs = requirementIds;
          

            return result;
        }




        public string? ID { get; set; }
        public List<string> RequirementIDs { get; set; }
        public string? Objective { get; set; }
        public string? ObjectIdentifier { get; set; }
        public string? A_ObjectType { get; set; }   
        


    }
}
