using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class Dummy
    {
        internal static Dummy? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var result = new Dummy();
   
            result.SYRID = reader.GetStringOrNull(header.GetColumnIndex("ICS list"))?.ToString();



            return result;
        }
        public string? SYRID { get; set; }



    }
}
