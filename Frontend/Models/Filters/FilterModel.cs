namespace Frontend.Models.Filters;

public abstract class FilterModel(
    int id,
    string name
)
{
    public int Id { get; } = id;
    public string Name { get; } = name;

    public abstract bool IsSelected();
}