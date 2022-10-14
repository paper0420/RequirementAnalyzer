using ExcelDataReader;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.ENG9TestSpec
{
    public class ENG9ExcelTableReader
    {
        public static WorksheetData<T> ReadFile<T>(
            string file,
            string sheet,
            int rowNo,
            Func<IExcelDataReader, Header, T> func)
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
                                var row = func(reader, worksheet.Header);

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
    }
}