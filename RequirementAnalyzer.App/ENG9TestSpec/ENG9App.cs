using RequirementsAndTestcasesAnalyzer.App;
using RequirementsAndTestcasesAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.ENG9TestSpec
{
    public static class ENG9App
    {
        public static void ReadTestSpec()
        {

            var g70TestcasesFusa = ENG9ExcelTableReader
            .ReadFile(FileNames.G70, FileNames.FusaSheet,7, (t, y) => ENG9Testcase.CreateOrNull(t, y))
            .DataRows
            .Where(t => t != null)
            .ToList();

            var g70TestcasesFunctional = ENG9ExcelTableReader
            .ReadFile(FileNames.G70, FileNames.FunctionalSheet, 7, (t, y) => ENG9Testcase.CreateOrNull(t, y))
            .DataRows
            .Where(t => t != null)
            .ToList();

            var g60TestcasesFusa = ENG9ExcelTableReader
             .ReadFile(FileNames.G60, FileNames.FusaSheet, 7, (t, y) => ENG9Testcase.CreateOrNull(t, y))
             .DataRows
             .Where(t => t != null)
             .ToList();

            var g60TestcasesFunctional = ENG9ExcelTableReader
            .ReadFile(FileNames.G60, FileNames.FunctionalSheet, 7, (t, y) => ENG9Testcase.CreateOrNull(t, y))
            .DataRows
            .Where(t => t != null)
            .ToList();

            List<ENG9Testcase> eng9TestCases = new List<ENG9Testcase>();
            eng9TestCases = g70TestcasesFusa.Concat(g70TestcasesFunctional)
                .Concat(g60TestcasesFusa).Concat(g60TestcasesFunctional).ToList();
            

            foreach(var tc in eng9TestCases)
            {
                Console.WriteLine(tc.ICSID.SelectMany(t=>t));
            }

        }
    }
}
