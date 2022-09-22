using RequirementsAndTestcasesAnalyzer.App;
using RequirementsAndTestcasesAnalyzer.Domain;
using RequirementsAndTestcasesAnalyzer.SpecParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.HtmlReportGen
{
    public static class HtmlDeltaAnalysis
    {
        public static void GenerateDeltaAnalysisPage(SpecForDeltaAnalysis spec)
        {
            DateTime now = DateTime.Now;
            string testcaseDetail = null;
            string header = $"<html>" +
                $"<head>" +
                $"<style>" +
                $"table,th,td {{border: 1px solid black;}}" +
                $"table.version {{border: 1px solid white;" +
                $"color:grey;" +
                $"width: 50%}}" +
                $"</style>" +
                $"</head>";
            string version = $"<table class=\"version\">" +
                $"<tr>" +
                $"<td>KPIT</br>Date:{now.ToString("dddd, dd MMMM yyyy")}</td>" +
                $"<td>{Path.GetFileName(FileNames.SYR)}" +
                $"</br>{Path.GetFileName(FileNames.DeltaSYR)}" +
                $"</td>" +
                $"</tr>" +
                $"</table>";


            string end = "</html>";

            foreach (string file in Directory.GetFiles(FileNames.SWReqFolder, "*.xlsx"))
            {
                var deltaDiagJP = ExcelTableReader.ReadFile(file, "Sheet1", (t, y) => SR.CreateOrNull(t, y)).DataRows;
                Console.WriteLine($"--------------------{Path.GetFileName(file)}----------------------------");

                testcaseDetail += $"<p>{Path.GetFileName(file)}</p>" +
                    $"<table style=\"width:50%\">" +
                    $"<tr>" +
                    $"<th style=\"width:30%\">Modified/New SR ID</th>" +
                    $"<th style=\"width:30%\">Affected KLH IDs</th>" +
                    $"<th style=\"width:40%\">Affected TestCase IDs</th>" +
                    $"</tr>"+
                    $"</table>";

                var klhIds = new HashSet<string>();
                foreach (var sr in deltaDiagJP)
                {

                    foreach (var rtmItem in spec.RTM_SR_KLHs)
                    {
                        if (sr.ID == rtmItem.SRID)
                        {
                            if (!klhIds.Contains(rtmItem.KLHID))
                            {
                                foreach (var tc in spec.TestCases)
                                {
                                    if (tc.Result != null)
                                    {
                                        foreach (var req in tc.RequirementIDs)
                                        {
                                            if (rtmItem.KLHID == req)
                                            {
                                                Console.WriteLine($"{sr.ID} {rtmItem.KLHID} {tc.ID}");
                                                testcaseDetail += $"<table style=\"width:50%\">" +
                                                $"<tr>" +
                                                $"<td style=\"width:30%\">{sr.ID}</td>" +
                                                $"<td style=\"width:30%\">{rtmItem.KLHID}</td>" +
                                                $"<td style=\"width:40%\">{tc.ID}</td>" +
                                                $"</tr>" +
                                                $"</table>";
                                            }
                                        }

                                    }

                                }
                                klhIds.Add(rtmItem.KLHID);
                            }
                        }
                    }
                }

            }

            var completeSYRs = DataPreparation.GetSYRandKLHlinked(spec.SYRs).ToList();
            var syrsByObjectID = new Dictionary<string, SYR>();
            syrsByObjectID = completeSYRs.Where(t => t.ObjectIdentifier != null).DistinctBy(t => t.ObjectIdentifier).ToDictionary(t => t.ObjectIdentifier);

            var completeDeltaSYRs = DataPreparation.GetSYRlinkedtoDelta(syrsByObjectID, spec.DeltaSYRs).ToList();

            var completeExecutedTCs = DataPreparation.GetSYRLinkedtoTestcases(spec.SYRs, spec.TestCases, spec.SCs).ToList();

            var affectedSyr = completeDeltaSYRs
                .Where(t => !string.IsNullOrWhiteSpace(t?.SYRID))
                .Select(t => t!.SYRID)
                .Cast<string>()
                .ToHashSet();

            var testCasesAffectedBySyr = completeExecutedTCs
                .Where(t => affectedSyr.Overlaps(t.RequirementIDs))
                .Select(t => t.ID)
                .ToHashSet();

            var affectedKlh = completeDeltaSYRs
                .Select(t => t?.Objective
                    .SubstringFrom("<ReqID>", inclusive: false)
                    .SubstringUpTo("</ReqID>")
                    .SubstringUpTo("<\\ReqID>"))
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .SelectMany(t => t!.Split(';', ':', ' '))
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Select(t => t.Trim())
                .Where(t => int.TryParse(t, out var _))
                .ToHashSet();

            var testCasesAffectedByKlh = completeExecutedTCs
                .Where(t => affectedKlh.Overlaps(t.RequirementIDs))
                .Where(t => t.Result != null)
                .Select(t => t.ID)
                .ToList();

            testcaseDetail += $"<p>{Path.GetFileName(FileNames.DeltaSYR)}</p>" +
                $"<table style=\"width:50%\">" +
                $"<tr>" +
                $"<th style=\"width:50%\">Modified/New SYR IDs</th>" +
                $"<th style=\"width:50%\">Affected TestCase IDs</th>" +
                $"</tr>" +
                $"</table>";

            testcaseDetail += $"<table style=\"width:50%\">" +
             $"<tr>" +
             $"<td style=\"width:50%\">{string.Join("\n", affectedSyr)}</td>" +
             $"<td style=\"width:50%\">{string.Join("\n", testCasesAffectedBySyr)}</td>" +
             $"</tr>" +
             $"</table>";

            testcaseDetail += $"<table style=\"width:50%\">" +
              $"<tr>" +
              $"<th style=\"width:50%\">Affected KLH IDs</th>" +
              $"<th style=\"width:50%\">Affected TestCase IDs</th>" +
              $"</tr>" +
              $"</table>";

            testcaseDetail += $"<table style=\"width:50%\">" +
                 $"<tr>" +
                 $"<td style=\"width:50%\">{string.Join("\n", affectedKlh)}</td>" +
                 $"<td style=\"width:50%\">{string.Join("\n", testCasesAffectedByKlh)}</td>" +
                 $"</tr>" +
                 $"</table>";


            Console.WriteLine($"Modified/New SYR:");
            Console.WriteLine();
            Console.WriteLine($"{string.Join("\n", affectedSyr)}");
            Console.WriteLine();
            Console.WriteLine($"Affected testcase by SYR:");
            Console.WriteLine($"{string.Join("\n", testCasesAffectedBySyr)}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Affected KLHs:");
            Console.WriteLine();
            Console.WriteLine($"{string.Join("\n", affectedKlh)}");
            Console.WriteLine();
            Console.WriteLine($"Affected testcase by KLH:");
            Console.WriteLine($"{string.Join("\n", testCasesAffectedByKlh)}");

            string html = header + version + testcaseDetail + end;

            File.WriteAllText(FileNames.DeltaPath, html);

        }


    }
}

