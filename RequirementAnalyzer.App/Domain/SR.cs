using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.Domain
{
    public class SR
    {
        internal static SR? CreateOrNull(IExcelDataReader reader, Header header)
        {
            var index = header.GetColumnIndex("SR-ID");
            if(index == null)
            {
                return null;
            }
            var id = reader.GetValue(index.Value)?.ToString().Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            var result = new SR();
            result.ID = id;

            return result;
        }
        public string? ID { get; set; }

    }
}
