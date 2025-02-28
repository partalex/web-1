using Microsoft.AspNetCore.Components;
using static System.String;

namespace Frontend.Models.Filters;

public class FilterTextModel(
    int id,
    string name,
    EventCallback<string> onFilterChanged
)
    : FilterModel(id, name)
{
    public readonly string Placeholder = "Naziv materijala";

    private EventCallback<string> OnFilterChanged { get; } = onFilterChanged;

    public string Value { get; set; } = Empty;

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

    public override bool IsSelected()
    {
        return !IsNullOrEmpty(Value);
    }
}