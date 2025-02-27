namespace Shared.Realisations;

public class FilterOption(int id, string name)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
}