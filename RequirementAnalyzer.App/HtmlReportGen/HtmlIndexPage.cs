using RequirementsAndTestcasesAnalyzer.App;
using RequirementsAndTestcasesAnalyzer.Domain;
using RequirementsAndTestcasesAnalyzer.SpecParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RequirementsAndTestcasesAnalyzer.HtmlReportGen
{
    public static class HtmlIndexPage
    {
        public static void GenerateTraceAbilityPage(SpecForCheckingBaseline spec)
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
                $"<td>{Path.GetFileName(FileNames.ENG10TestSpecFile)}" +
                $"</br>{FileNames.KLHFileName}" +
                $"</br>{Path.GetFileName(FileNames.SYR)}" +
                $"</br>{Path.GetFileName(FileNames.EPIC)}" +
                $"</br>{Path.GetFileName(FileNames.TSR)}" +
                $"</td>" +
                $"</tr>" +
                $"</table>";
            string column = $"<table style=\"width:50%\">" +
                $"<tr>" +
                $"<th>ENG10HV Test Case ID</th>" +
                $"<th>KLH IDs</th>" +
                $"<th>SYR IDs</th>" +
                $"<th>TSR IDs</th>" +
                $"</tr>";

            string end = "</table></html>";
            foreach (var testCase in spec.TestCases)
            {
                var syrHtml = "";
                var reqHtml = "";
                var tsrHtml = "";

                if (testCase.SYRIDs.Count > 0)
                {
                    syrHtml = GetSYRsHtml(testCase, spec);

                }

                reqHtml = GetReqsHtml(testCase, spec);

                if (testCase.TSRIDs.Count > 0)
                {
                    tsrHtml = GetTSRsHtml(testCase, spec);
                }

                var tcPath = $".\\Requirements\\{testCase.ID.Replace("#", "")}.html";
                testcaseDetail += $"<tr>" +
                    $"<td style=\"width:40%\"><a href='{tcPath}'>{testCase.ID}</a></td>" +
                    $"<td style=\"width:20%\">{reqHtml}</td>" +
                    $"<td style=\"width:20%\">{syrHtml}</td>" +
                    $"<td style=\"width:20%\">{tsrHtml}</td>" +
                    $"</tr>";

            }
            string html = header + version + column + testcaseDetail + end;

            File.WriteAllText(FileNames.IndexPath, html);

        }

        private static string GetTSRsHtml(ENG10Testcase testCase, SpecForCheckingBaseline spec)
        {
            var html = "";
            foreach (var tsr in testCase.TSRIDs)
            {
                var tsrPath = $".\\Requirements\\{tsr}.html";
                html += $"<a>{tsr}</a>" +
                        "</br>";
            }
            return html;

        }

        private static string GetSYRsHtml(ENG10Testcase testCase, SpecForCheckingBaseline spec)
        {
            var html = "";
            foreach (var syr in testCase.SYRIDs)
            {
                var syrPath = $".\\Requirements\\{syr}.html";
                html += $"<a href='{syrPath}'>{syr}</a>" +
                        "</br>";
            }
            return html;

        }

        private static string GetReqsHtml(ENG10Testcase testcase, SpecForCheckingBaseline spec)
        {
            var html = "";
            foreach (var req in testcase.RequirementIDs)
            {
                if (!req.Contains("CCU-"))
                {
                    html += $"<a>{req}</a>" +
                        "</br>";
                }
                else
                {
                    var reqPath = $".\\Requirements\\{req}.html";
                    html += $"<a href='{reqPath}'>{req}</a>" +
                            "</br>";

                }
            }
            return html;

        }
    }
}

