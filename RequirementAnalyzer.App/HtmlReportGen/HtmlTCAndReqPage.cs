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
    public static class HtmlTCAndReqPage
    {       
        public static void GenerateTestCaseAndRequirementPage(SpecForCheckingBaseline spec)
        {
            string header = $"<html>" +
                   $"<head>" +
                   $"<style>" +
                   $".klh {{color: grey;}}" +
                   $"</style>" +
                   $"</head>";

            string end = "</html>";

            foreach (var testCase in spec.TestCases)
            {
                if (testCase.ID != null)
                {
                    string testCaseDetail = CreateTestCaseHtml(spec, testCase);

                    var tcPath = Path.GetFullPath($"{testCase.ID.Replace("#", "")}.html", FileNames.RequirementsFolder);
                    File.WriteAllText(
                        tcPath,
                        header+testCaseDetail+end);
                }
            }


        }

        private static string CreateTestCaseHtml(SpecForCheckingBaseline spec, ENG10Testcase testCase)
        {
            string requirementsHtml = GenerateRequirementsHtml(
                spec,
                testCase);
            string tsrRequirementsHtml = GenerateTSRRequirementsHtml(
             spec,
             testCase);


            string testCaseDetail =
                $"<a href='..\\Index.html'>Home</a>" +
                $"<h1>{testCase.ID}</h1>\n" +
                $"[{testCase.ItemClass1}],[{testCase.ItemClass2}],[{testCase.ItemClass3}]" +
                $"</br>" +
                $"Test Objective: {testCase.Objective}<br>\n" +
                $"<h2>Requirements</h2>" +
                $"{requirementsHtml}" +
                $"{tsrRequirementsHtml}";
            return testCaseDetail;

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
                    $"<div class='klh'>[{requirement.changeStatus}][{requirement.panaStatus}][{requirement.VerificationMeasure}][{requirement.Type}]</div>" +
                    $"{requirement.Objective}" +
                    $"</li>";
            }

            requirementsHtml += "</ul>";

            return requirementsHtml;
        }


        private static string GenerateTSRRequirementsHtml(SpecForCheckingBaseline spec, ENG10Testcase testCase)
        {
            string requirementsHtml = "<ul>";
            foreach (var tsrId in testCase.TSRIDs)
            {
                var tsr = spec.TSRsByID.ContainsKey(tsrId) ? spec.TSRsByID[tsrId] : null;

                requirementsHtml +=
                    $"<li>" +
                    $"<strong>{tsrId}</strong> - " +
                    $"<div>{tsr.Objective}<div>" +
                    $"</li>\n";
            }

            requirementsHtml += "</ul>";

            return requirementsHtml;
        }

    }
}

