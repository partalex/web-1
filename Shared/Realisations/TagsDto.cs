using Shared.Models;
using static System.String;

namespace Shared.Realisations;

public class TagsDto
{
    public int TagId { get; init; }
    public string Value { get; init; } = Empty;
}

public class ItemDto
{
    public int Id { get; init; }
    public List<TagsDto> Tags { get; init; } = [];
}

public class FilterDto
{
    public int TagId { get; init; }
    public required string Name { get; init; }
    public FilterType FilterType { get; init; }
    public IEnumerable<string> Values { get; init; } = [];
}

public class Container<T>
{
    public List<FilterDto> Filters { get; init; } = [];
    public List<T> Items { get; init; } = [];
}