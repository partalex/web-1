using Shared.Models;

namespace MudBlazorWebApp1.Services;

public class ServiceService(HttpClient httpClient)
    : ServiceApiGet<Service>(httpClient, "api/Service")
{
    public async Task<IEnumerable<Service>> GetAvailable()
    {
        var respond = await HttpClient.GetAsync($"{Path}/available");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<IEnumerable<Service>>();
        return data ?? [];
    }

    public async Task<IEnumerable<Service>> GetFeatured()
    {
        var respond = await HttpClient.GetAsync($"{Path}/featured");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<IEnumerable<Service>>();
        return data ?? [];
    }
}