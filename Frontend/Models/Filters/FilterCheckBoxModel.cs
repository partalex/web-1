using Microsoft.AspNetCore.Components;
using Shared.Realisations;

namespace Frontend.Models.Filters;

public class FilterCheckBoxModel(
    int id,
    FilterInfo filterInfo,
    EventCallback<List<int>> onFilterChanged)
    : FilterModel(id, filterInfo.Name)
{
    public List<FilterOption> Options { get; } = filterInfo.Options;

    public class TempClass(int id, bool value = false)
    {
        public int Id { get; set; } = id;
        public bool Value { get; set; } = value;
    }

    public void UpdateValue(int id, bool value)
    {
        Values[id].Value = value;
    }

    public List<TempClass> Values { get; set; } =
        filterInfo.Options.Select(option => new TempClass(option.Id)).ToList();

    private EventCallback<List<int>> OnFilterChanged { get; } = onFilterChanged;

    public override bool IsSelected()
    {
        return Values.Any(value => value.Value);
    }

    public async void FilterChanged()
    {
        try
        {
            await OnFilterChanged.InvokeAsync(Values.Where(value => value.Value).Select(value => value.Id).ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}