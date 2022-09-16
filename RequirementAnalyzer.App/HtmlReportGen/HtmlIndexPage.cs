using RequirementsAndTestcasesAnalyzer.App;
using RequirementsAndTestcasesAnalyzer.Domain;
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
                $"<td>{FileNames.TestSpecFileName}</br>{FileNames.KLHFileName}</br>{FileNames.SYRName}</br>{FileNames.EPICName}</td>" +
                $"</tr>" +
                $"</table>";
            string column = $"<table style=\"width:50%\">" +
                $"<tr>" +
                $"<th>ENG10HV Test Case ID</th>" +
                $"<th>KLH IDs</th>" +
                $"<th>SYR IDs</th>" +
                $"</tr>";

            string end = "</table></html>";
            foreach (var testCase in spec.TestCases)
            {
                if (testCase.Result != null)
                {
                    var syrHtml = "";
                    var reqHtml = "";

                    if (testCase.SYRIDs.Count > 0)
                    {
                        syrHtml = GetSYRsHtml(testCase,spec);

                    }

                    //if (testCase.RequirementIDs.Contains("CCU-"))
                    {
                        reqHtml = GetReqsHtml(testCase, spec);
                    }


                    var tcPath = $".\\Requirements\\{testCase.ID.Replace("#", "")}.html";
                    testcaseDetail += $"<tr>" +
                        $"<td style=\"width:40%\"><a href='{tcPath}'>{testCase.ID}</a></td>" +
                        $"<td style=\"width:30%\">{reqHtml}</td>" +
                        $"<td style=\"width:30%\">{syrHtml}</td>" +
                        $"</tr>";


                }
            }
            string html = header+version + column + testcaseDetail + end;

            File.WriteAllText(FileNames.IndexPath, html);

        }

        private static string GetSYRsHtml(ENG10Testcase testcase, SpecForCheckingBaseline spec)
        {
            var html = "";
            foreach(var syr in testcase.SYRIDs)
            {
                var syrPath = $".\\Requirements\\{syr}.html";
                html += $"<a href='{syrPath}'>{syr}</a>"+
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

