using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using RequirementsAndTestcasesAnalyzer.App;
using RequirementsAndTestcasesAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.ENG9TestSpec
{
    public static class ENG9App
    {
        public static Dictionary<string, ENG9Testcase> ReadTestReport()
        {
            var testCaseFusa = GetTestCasesFromSheet(FileNames.ENG9Folder, FileNames.FusaSheet);
            var testCaseFunctional = GetTestCasesFromSheet(FileNames.ENG9Folder, FileNames.FunctionalSheet);
            var testCaseFTT = GetTestCasesFromSheet(FileNames.ENG9Folder, FileNames.FTTSheet);
            foreach(var tc in testCaseFusa)
            {
                tc.Group = "Fusa";
            }
            foreach (var tc in testCaseFunctional)
            {
                tc.Group = "Functional";
            }
            foreach (var tc in testCaseFTT)
            {
                tc.Group = "FTT";
            }


            List<ENG9Testcase> alleng9TestCases = new List<ENG9Testcase>();
            alleng9TestCases = testCaseFusa.Concat(testCaseFunctional)
                .Concat(testCaseFTT).ToList();

            var eng9TestCasesById = new Dictionary<string, ENG9Testcase>();
            var eng9TestCases = new List<ENG9Testcase>();

            foreach (var item in alleng9TestCases)
            {
                foreach (var tc in item.IDs)
                {
                    if (!eng9TestCasesById.ContainsKey(tc))
                    {
                        var eng9TC = new ENG9Testcase();
                        eng9TC.ID = tc;
                        eng9TC.REQID = item.REQID;
                        eng9TC.FusaType = GetGroupID(tc, item.REQID);
                        eng9TC.Group = item.Group;
                        //eng9TestCases.Add(eng9TC);
                        eng9TestCasesById.Add(tc, eng9TC);
                    }
                    else
                    {
                        var testCase = eng9TestCasesById[tc];
                        testCase.REQID.AddRange(item.REQID);
                        testCase.REQID = testCase.REQID.Distinct().ToList();
                        testCase.CarLines.AddRange(item.CarLines);
                        testCase.CarLines = testCase.CarLines.Distinct().ToList();

                    }

                }

            }

            foreach (var item in eng9TestCasesById)
            {
                var tsrIDs = item.Value.REQID.Where(t => t.Contains("TSR-CCU")).ToList();
                var icsIDs = item.Value.REQID.Where(t => t.Contains("SYS3")).ToList();
                var syrIDs = item.Value.REQID.Where(t => t.Contains("SYR")).ToList();
                var klhIds = item.Value.REQID.Where(t => int.TryParse(t, out var _)).ToList();

                item.Value.KLHID.AddRange(klhIds);
                item.Value.KLHID = item.Value.KLHID.Distinct().ToList();
                item.Value.TSRID.AddRange(tsrIDs);
                item.Value.TSRID = item.Value.TSRID.Distinct().ToList();
                item.Value.ICSID.AddRange(icsIDs);
                item.Value.ICSID = item.Value.ICSID.Distinct().ToList();
                item.Value.SYRID.AddRange(syrIDs);
                item.Value.SYRID = item.Value.SYRID.Distinct().ToList();
            }
            return eng9TestCasesById;
        }

        private static string GetGroupID(string tc, List<string> req)
        {
            if (tc.Contains("AC3"))
            {
                return "AC3";
            }
            if (tc.Contains("AC4"))
            {
                return "AC4";
            }
            if (tc.Contains("AC6"))
            {
                return "AC6";
            }
            if (tc.Contains("AC7"))
            {
                return "AC7";
            }
            if (tc.Contains("DC1"))
            {
                return "DC1";
            }
            if (tc.Contains("FP"))
            {
                return "FP";
            }
            if (tc.Contains("FTT"))
            {
                return "FTT";
            }
            if (tc.Contains("SBW"))
            {
                return "SBW";
            }
            if (tc.Contains("SF01"))
            {
                return "SF01";
            }
            if (tc.Contains("SF02"))
            {
                return "SF02";
            }
            if (tc.Contains("SF03"))
            {
                return "SF03";
            }
            if (tc.Contains("EFAN"))
            {
                return "EFAN";
            }
            if (tc.Contains("SEV"))
            {
                return "SEV";
            }
            if (tc.Contains("COMMON"))
            {
                return "COMMON";
            }
            if(tc.Contains("SYI_001"))
            {
                if (req.Any(t=>t.Contains("TSR-CCU")))
                {
                    return "DCDC";
                }
                else
                {
                    return "DCDC_Function";
                }
                
            }

            return "Charger_Function";

        }

        private static List<ENG9Testcase> GetTestCasesFromSheet(string folder, string sheet)
        {
            var files = Directory.GetFiles(folder, "*.xlsx");
            var allTestCases = new List<ENG9Testcase>();

            foreach (var file in files)
            {
                var testCases = ENG9ExcelTableReader
                .ReadFile(file, sheet, 7, (t, y, cl) => ENG9Testcase.CreateOrNull(t, y, cl))
                .DataRows
                .Where(t => t != null)
                .ToList();

                allTestCases.AddRange(testCases);
            }
            return allTestCases;
        }


        public static Dictionary<string, ENG9Spec> ReadTestSpec()
        {
            var files = Directory.GetFiles(FileNames.ENG9SepFolder, "*.xlsx");
            var allTestCases = new List<ENG9Spec>();
            var testCasesbyID = new Dictionary<string, ENG9Spec>();
            foreach (var file in files)
            {
                var testCases = ENG9ExcelTableReader
                .ReadFile(file, "Test_Item", 16, (t, y, cl) => ENG9Spec.CreateOrNull(t, y, cl))
                .DataRows
                .Where(t => t != null)
                .ToList();

                allTestCases.AddRange(testCases);
            }

            foreach (var tc in allTestCases)
            {
                if (!testCasesbyID.ContainsKey(tc.ID))
                {
                    var eng9TC = new ENG9Spec();
                    eng9TC.ID = tc.ID;
                    eng9TC.Objective = tc.Objective;
                    testCasesbyID.Add(tc.ID, eng9TC);
                }
                else
                {
                    var testCase = testCasesbyID[tc.ID];
                    if(testCase.Objective == tc.Objective)
                    {
                        continue;
                    }
                    else
                    {
                        testCase.Objective = $"{testCase.Objective}\n{tc.Objective}";
                    }

                }

            }


            return testCasesbyID;
        }






    }
}
