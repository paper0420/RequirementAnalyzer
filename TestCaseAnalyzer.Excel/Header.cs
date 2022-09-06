namespace TestCaseAnalyzer.App.FileReader;

public class Header
{
    private Dictionary<string,Column>? columnsById;
    public List<Column> Columns { get; } = new();
    
    public int GetColumnIndex(string name)
    {
        if (this.columnsById == null)
        {
            this.columnsById = this.Columns
                .Where(t => !string.IsNullOrWhiteSpace(t.Name))
                .ToDictionary(t => t.Name!);
        }

        if (this.columnsById.ContainsKey(name))
        {
            return this.columnsById[name].Index;    
        }

        throw new Exception($"Cannot find column `{name}`.");
    }
}