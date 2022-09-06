using System.Collections.Generic;

namespace TestCaseAnalyzer.App.FileReader;

public class WorksheetData<T>
{
    public List<T> DataRows { get; init; } = new();
    public Header Header { get; init; } = new();
}