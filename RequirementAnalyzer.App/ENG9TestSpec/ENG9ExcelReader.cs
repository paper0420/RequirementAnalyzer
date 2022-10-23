using ExcelDataReader;
using System.Dynamic;
using System.Linq;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.ENG9TestSpec
{
    public class ENG9ExcelTableReader
    {
        public static WorksheetData<T> ReadFile<T>(
            string file,
            string sheet,
            int rowNo,
            Func<IExcelDataReader, Header,string, T> func)
        {
            using (var stream = File.Open(file, FileMode.Open, FileAccess.Read))
            {
                var worksheet = new WorksheetData<T>();
                
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        if (reader.Name == sheet || reader.Name.Contains(sheet))
                        {
                            for(var i= 0; i<rowNo-1; i++)
                            {
                                reader.Read();

                            }


                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var column = new Column
                                {
                                    Index = i,
                                    Name = reader.GetValue(i)?.ToString()
                                };

                                worksheet.Header.Columns.Add(column);
                            }

                            while (reader.Read())
                            {
                                var carLine = GetCarLine(file);
                                var row = func(reader, worksheet.Header,carLine);

                                if (row != null)
                                {
                                    worksheet.DataRows.Add(row);
                                }
                            }
                        }

                    } while (reader.NextResult());
                }

                return worksheet;
            }
        }
    
        private static string GetCarLine (string file)
        {
            var carLines = new string[] { "G70", "G60", "G26","I20","G28","G08LCI","U11" };
            var result = CheckCarLine(carLines,file);

            return result;
        }

        private static string CheckCarLine(string[] carLines,string file)
        {
            foreach(var carLine in carLines)
            {
                if (Path.GetFileNameWithoutExtension(file).Contains($"_{carLine}_"))
                {
                    return carLine;
                }

            }

            return "No car line matched";
            
        }
    }
}