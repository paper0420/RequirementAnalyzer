using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class EPIC
    {
        internal static EPIC? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var result = new EPIC();
            result.JiraTicketNumber = reader.GetStringOrNull(header.GetColumnIndex("A_JIRA Ticket Number"))?.ToString().Trim();
            result.Objective = reader.GetStringOrNull(header.GetColumnIndex("Objective"))?.ToString();
            result.Description = reader.GetStringOrNull(header.GetColumnIndex("A_Description"))?.ToString();



            return result;
        }
        public string? JiraTicketNumber { get; set; }
        public string? Description { get; set; }
        public string Objective { get; set; }


    }
}
