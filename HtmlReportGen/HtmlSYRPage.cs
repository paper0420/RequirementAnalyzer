using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequirementsAndTestcasesAnalyzer.HtmlReportGen
{
    public static class HtmlSYRPage
    {
        public static void GenerateSYR(SpecForCheckingBaseline spec)
        {
            string syrID = "";
            string reqDetail = "";
            var reqCheck = new HashSet<string>();
            string navbar = $"<a href='./index.html'>Home</a>";

            foreach (var req in spec.SYRs)
            {
                if(req.ID != null)
                {
                    if (!reqCheck.Contains(req.ID))
                    {
                        reqDetail = GetObjective(spec, req.ID);
                        File.WriteAllText($"report/{req.ID}.html", navbar+reqDetail);
                        reqCheck.Add(req.ID);
                    }

                }

            }
        }

        public static string GetObjective(SpecForCheckingBaseline spec, string syrID)
        {
            string reqObjective = "";
            string syr_ID = $"<h1>{syrID}</h1></br>";
            foreach(var syr in spec.SYRs)
            {
                if(syr.ID == syrID)
                {
                    reqObjective += $"<li>" +
                        $"{syr.Objective}</br>" +
                        $"</li>";
                }
            }
            return syr_ID+reqObjective;
        }
    }
}
