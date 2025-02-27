using Shared.Models;
using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public class ManufacturerService(HttpClient httpClient)
    : ServiceApiGet<Manufacturer>(httpClient, "api/Manufacturer")

{
    public async Task<IEnumerable<ManufacturerDto>> GetPartners()
    {
        var respond = await HttpClient.GetAsync($"{Path}/partners");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<IEnumerable<ManufacturerDto>>();
        return data ?? [];
    }
}