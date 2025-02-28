using Microsoft.AspNetCore.Components;
using Shared.Realisations;

namespace Frontend.Models.Filters;

public class FilterRadioModel(
    int id,
    FilterInfo filterInfo,
    EventCallback<int> onFilterChanged
)
    : FilterModel(id, filterInfo.Name)
{
    public List<FilterOption> Options { get; } = filterInfo.Options;

    public int? Value;

    private EventCallback<int> OnFilterChanged { get; } = onFilterChanged;

    public override bool IsSelected()
    {
        return Value != null;
    }

    public async void FilterChanged()
    {
        try
        {
            await OnFilterChanged.InvokeAsync(Value!.Value);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}