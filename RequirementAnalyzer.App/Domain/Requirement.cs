using ExcelDataReader;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class Requirement
    {
        private Requirement(string id)
        {
            this.ID = id;
            this.EpicIDs = new string[0];
        }

        public static Requirement? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var idColumn = header.GetColumnIndex("Object ID from Original");
            var id = reader.GetValue(idColumn)?.ToString();

            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            Requirement requirement = new Requirement(id);

            requirement.changeStatus = reader.GetString(header.GetColumnIndex("A_Change Status"));
            requirement.panaStatus = reader.GetString(header.GetColumnIndex("A_Pana Status"));
            requirement.VerificationSpecStatus = reader.GetValue(header.GetColumnIndex("A_Verification_Specification_Status"))?.ToString();
            requirement.FusaType = reader.GetValue(header.GetColumnIndex("EAS_ASIL"))?.ToString();
            requirement.Objective = reader.GetString(header.GetColumnIndex("Englisch"));
            requirement.VerificationMeasure = reader.GetValue(header.GetColumnIndex("A_Verification_Measure"))?.ToString()?.Replace("\n", "");
            requirement.Type = reader.GetValue(header.GetColumnIndex("A_ItemType"))?.ToString();

            return requirement;

            //this.EpicIDs = reader
            //    .GetString(21)?
            //    .Split("\n", System.StringSplitOptions.RemoveEmptyEntries)
            //    ?? new string[0];
        }

        public string ID { get; private set; }
        public string? Objective { get; private set; }
        public string? changeStatus { get; private set; }
        public string? panaStatus { get; private set; }
        public string? VerificationSpecStatus { get; private set; }
        public string? VerificationMeasure { get; private set; }
        public string? Type { get; private set; }
        public string[] EpicIDs { get; private set; }
        public string? FusaType { get; private set; }



    }
}