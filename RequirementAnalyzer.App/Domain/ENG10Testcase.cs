using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class ENG10Testcase
    {
        private static IEnumerable<string> GetAvailableCarlines(
            IExcelDataReader reader,
            Header header,
            List<string> carLineNames)
        {
            foreach (var carLineName in carLineNames)
            {
                var carLineColumnName = $"#{carLineName}#";
                var columnIndex = header.GetColumnIndex(carLineColumnName);
            
                var contains = reader.GetStringOrNull(columnIndex)?.ToString()?.Contains("X") == true;

                if (contains)
                {
                    yield return carLineName;
                }
            }
        }

        internal static ENG10Testcase? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var id = reader.GetStringOrNull(header.GetColumnIndex("Test Case ID"))?.ToString();

            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            var result = new ENG10Testcase();

            result.ID = id;
            result.Objective = reader.GetStringOrNull(header.GetColumnIndex("Test objective"));
            var idsAsString = reader.GetStringOrNull(header.GetColumnIndex("Current KLH"))?
                .ToString()?
                .Split('\n') ?? new string[0];

            //var requirementIds = new List<int>();
            var requirementIds = new List<string>();
            var epicIds = new List<string>();


            foreach (var idAsString in idsAsString)
            {
                //var isInt = int.TryParse(idAsString, out int idAsInt);

                //if (isInt)
                //{
                //    requirementIds.Add(idAsInt);
                //}
                //else
                //{
                //    epicIds.Add(idAsString);
                //}

                requirementIds.Add(idAsString);


            }

            result.RequirementIDs = requirementIds;
            result.EpicIDs = epicIds.ToArray();

            if (CarLineNames.carLineNames == null)
            {
                CarLineNames.carLineNames = header.Columns
                .Where(t => t.Name != null)
                .Where(t => t.Name!.StartsWith("#"))
                .Where(t => t.Name!.EndsWith("#"))
                .Select(t => t.Name!.Replace("#", "").Replace("#", ""))
                .ToList();
            }

            result.Carlines = GetAvailableCarlines(
                    reader,
                    header,
                    CarLineNames.carLineNames)
                .ToList();

            result.Type = reader.GetStringOrNull(header.GetColumnIndex("Type"))?.ToString();
            result.Result = reader.GetStringOrNull(header.GetColumnIndex("Result"))?.ToString()?.Replace("\n", " ");

            result.ItemClass1 = reader.GetStringOrNull(header.GetColumnIndex("Class1"));
            result.ItemClass2 = reader.GetStringOrNull(header.GetColumnIndex("Class2"));
            result.ItemClass3 = reader.GetStringOrNull(header.GetColumnIndex("Class3"));

            result.Comment = reader.GetStringOrNull(header.GetColumnIndex("Comment"))?.ToString();

            result.VerificationMethod = reader.GetStringOrNull(header.GetColumnIndex("Verification Method"))?.ToString();
            result.TestCatHV = reader.GetStringOrNull(header.GetColumnIndex("TestCat-HV"))?.ToString();
            result.TestCatBasic = reader.GetStringOrNull(header.GetColumnIndex("TestCat-HV"))?.ToString();
            result.TestCatFusa = reader.GetStringOrNull(header.GetColumnIndex("TestCat-Fusa"))?.ToString();
            result.TestCatFunc = reader.GetStringOrNull(header.GetColumnIndex("TestCat-Func"))?.ToString();
            result.TestCatFull = reader.GetStringOrNull(header.GetColumnIndex("TestCat-Full"))?.ToString();

            return result;
        }

        public string ID { get; set; }
        public List<string> RequirementIDs { get; set; }
        public string[] EpicIDs { get; private set; }
        public List<string> Carlines { get; private set; }
        public string Type { get; private set; }
        public string? Result { get; set; }
        public string Objective { get; set; }
        public string ItemClass1 { get; set; }
        public string ItemClass2 { get; set; }
        public string ItemClass3 { get; set; }
        public string Comment { get; private set; }
        public string VerificationMethod { get; private set; }
        public string TestCatHV { get; private set; }
        public string TestCatBasic { get; private set; }
        public string? TestCatFusa { get; private set; }
        public string? TestCatFunc { get; private set; }
        public string? TestCatFull { get; private set; }

        public HashSet<string>? SYRIDs { get; set; } = new HashSet<string>();
        public List<string>? TSRIDs { get; set; } = new List<string>();


    }
}
