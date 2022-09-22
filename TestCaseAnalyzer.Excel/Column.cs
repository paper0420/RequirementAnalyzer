namespace TestCaseAnalyzer.App.FileReader;

public class Column
{
    public int Index { get; init; }
    public string? Name { get; init; }

    public override string ToString()
    {
        return $"{this.Index} - {this.Name}";
    }
}