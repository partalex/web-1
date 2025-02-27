namespace Shared.Realisations;

public class FilterInfo(string name)
{
    public string Name { get; } = name;
    public List<FilterOption> Options { get; set; } = [];
}