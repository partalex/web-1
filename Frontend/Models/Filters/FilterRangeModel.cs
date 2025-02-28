using Microsoft.AspNetCore.Components;

namespace Frontend.Models.Filters;

public class FilterRangeModel(
    int id,
    string name,
    int minValue,
    int maxValue,
    EventCallback<Tuple<int, int>> onFilterChanged)
    : FilterModel(id, name)

{
    private EventCallback<Tuple<int, int>> OnFilterChanged { get; set; } = onFilterChanged;

    public Tuple<int, int> Value { get; set; } = new(minValue, maxValue);
    public int MinValue { get; set; } = minValue;
    public int MaxValue { get; set; } = maxValue;

    public override bool IsSelected()
    {
        return MinValue != 0 || MaxValue != 0;
    }

    public async void FilterChanged()
    {
        try
        {
            await OnFilterChanged.InvokeAsync(Value);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}