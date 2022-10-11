namespace TestCaseAnalyzer.App.FileReader;

public class Header
{
    private Dictionary<string,Column>? columnsById;
    public List<Column> Columns { get; } = new();
    
    /// <summary>
    /// get a column index by name.
    /// </summary>
    /// <param name="names">possible names of column</param>
    /// <returns></returns>
    public int? GetColumnIndex(params string[] names)
    {
        if (this.columnsById == null)
        {
            this.columnsById = this.Columns
                .Where(t => !string.IsNullOrWhiteSpace(t.Name))
                .ToDictionary(t => t.Name!);
        }

        foreach(var name in names)
        {
            if (this.columnsById.ContainsKey(name))
            {
                return this.columnsById[name].Index;
            }
        } 
        

        return null;
    }
}