using RequirementsAndTestcasesAnalyzer.App;
using RequirementsAndTestcasesAnalyzer.Domain;
using RequirementsAndTestcasesAnalyzer.SpecParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequirementsAndTestcasesAnalyzer.HtmlReportGen
{
    public static class HtmlEPICPage
    {
        public static void GenerateEPIC (SpecForCheckingBaseline spec)
        {
            string reqDetail = "";
            var reqCheck = new HashSet<string>();
            string navbar = $"<a href='..\\Index.html'>Home</a>";

            foreach (var req in spec.EPICs)
            {
                if(req.JiraTicketNumber!= null)
                {
                    if (!reqCheck.Contains(req.JiraTicketNumber))
                    {
                        reqDetail = GetObjective(req);

                        var epicPath = Path.GetFullPath($"{req.JiraTicketNumber}.html", FileNames.RequirementsFolder);
                        File.WriteAllText(epicPath, navbar+reqDetail);
                        reqCheck.Add(req.JiraTicketNumber);
                    }

                }

            }
        }

        public static string GetObjective(EPIC req)
        {
            string reqObjective = "";
            string jiraTicketNo = $"<h1>{req.JiraTicketNumber}</h1></br>";

            reqObjective = $"<strong>{req.Objective}</strong></br>" +
                $"{req.Description}";

            return jiraTicketNo+reqObjective;
        }
    }
}
