using RequirementsAndTestcasesAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RequirementsAndTestcasesAnalyzer.HtmlReportGen
{
    public static class HtmlTCAndReqPage
    {       
        public static void GenerateTestCaseAndRequirementPage(SpecForCheckingBaseline spec)
        {

            foreach (var testCase in spec.TestCases)
            {
                if (testCase.ID != null)
                {
                    string testCaseDetail = CreateTestCaseHtml(spec, testCase);

                    File.WriteAllText(
                        $"report/{testCase.ID.Replace("#", "")}.html",
                        testCaseDetail);
                }
            }


        }

        private static string CreateTestCaseHtml(SpecForCheckingBaseline spec, ENG10Testcase testCase)
        {
            string requirementsHtml = GenerateRequirementsHtml(
                spec,
                testCase);

            string header = $"<html>" +
                            $"<head>" +
                            $"<style>" +
                            $"p {{color: grey;}}" +
                            $"</style>" +
                            $"</head>";

            string end = "</html>";

            string testCaseDetail =
                $"<a href='./index.html'>Home</a>" +
                $"<h1>{testCase.ID}</h1>\n" +
                $"<p>[{testCase.ItemClass1}],[{testCase.ItemClass2}],[{testCase.ItemClass3}]</p>" +
                $"</br>" +
                $"Test Objective: {testCase.Objective}<br>\n" +
                $"<h2>Requirements</h2>" +
                $"{requirementsHtml}";
            return header+testCaseDetail+end;

        }



        private static string GenerateRequirementsHtml(SpecForCheckingBaseline spec, ENG10Testcase testCase)
        {
            var testCaseRequirements = spec.KLHs
                .Where(t => testCase.RequirementIDs.Any(c => c == t.ID))
                .ToList();

            string requirementsHtml = "<ul>";

            foreach (var requirement in testCaseRequirements)
            {


                requirementsHtml +=
                    $"<li>" +
                    $"<strong>{requirement.ID}</strong> - " +
                    $"[{requirement.changeStatus}] " +
                    $"[{requirement.panaStatus}] " +
                    $"[{requirement.VerificationMeasure}] " +
                    $"[{requirement.Type}]" +
                    $"<br>{requirement.Objective}" +
                    $"</li>\n";
            }

            requirementsHtml += "</ul>";

            return requirementsHtml;
        }

    }
}

