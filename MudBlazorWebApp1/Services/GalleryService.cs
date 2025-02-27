using Shared.Models;

namespace MudBlazorWebApp1.Services;

public class GalleryService(HttpClient httpClient)
    : ServiceApiGet<Gallery>(httpClient, "api/Gallery")

{
    public async Task<IEnumerable<NavCategories>> GetCategories()
    {
        var respond = await HttpClient.GetAsync($"{Path}/categories");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<IEnumerable<NavCategories>>();
        return data ?? [];
    }
}