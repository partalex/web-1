using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public class DecorService(HttpClient httpClient)
    : ServiceApiBase(httpClient, "api/Decor")
{
    public async Task<IEnumerable<DecorDto>> Filter(FilterParamsDecor filterParams)
    {
        var response = await HttpClient.PostAsJsonAsync($"{Path}/filter", filterParams);
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadFromJsonAsync<IEnumerable<DecorDto>>();
        return data ?? [];
    }
    
    public async Task<FilterDecor> GetFilters()
    {
        var response = await HttpClient.GetAsync($"{Path}/filters");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadFromJsonAsync<FilterDecor>();
        return data ?? new FilterDecor();
    }
}