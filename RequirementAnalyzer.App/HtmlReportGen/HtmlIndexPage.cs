﻿using RequirementsAndTestcasesAnalyzer.App;
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

            string testcaseDetail = null;
            string header = $"<html>" +
                $"<head>" +
                $"<style>" +
                $"table,th,td {{border: 1px solid black;}}" +
                $"</style>" +
                $"</head>";
            string column = $"<table style=\"width:50%\">" +
                $"<tr>" +
                $"<th>Test Case ID</th>" +
                $"<th>KLH IDs</th>" +
                $"<th>SYR IDs</th>" +
                $"</tr>";

            string end = "</table></html>";
            foreach (var testCase in spec.TestCases)
            {
                if (testCase.Result != null)
                {
                    var syrHtml = "";
                    if (testCase.SYRIDs.Count > 0)
                    {
                        syrHtml = GetSYRsHtml(testCase,spec);

                    }

                    var tcPath = Path.GetFullPath($"{testCase.ID.Replace("#", "")}.html", FileNames.RequirementsFolder);
                    testcaseDetail += $"<tr>" +
                        $"<td style=\"width:40%\"><a href='{tcPath}'>{testCase.ID}</a></td>" +
                        $"<td style=\"width:30%\">{string.Join("</br>", testCase.RequirementIDs)}</td>" +
                        $"<td style=\"width:30%\">{syrHtml}</td>" +
                        $"</tr>";


                }
            }
            string html = header + column + testcaseDetail + end;

            File.WriteAllText(FileNames.IndexPath, html);

        }

        private static string GetSYRsHtml(ENG10Testcase testcase, SpecForCheckingBaseline spec)
        {
            var html = "";
            foreach(var syr in testcase.SYRIDs)
            {
                var syrPath = Path.GetFullPath($"{syr}.html", FileNames.RequirementsFolder);
                html += $"<a href='{syrPath}'>{syr}</a>"+
                        "</br>";
            }
            return html;

        }

    }
}

