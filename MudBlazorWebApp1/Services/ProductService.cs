using MudBlazorWebApp1.Exceptions;
using Shared.Models;
using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public class ProductService(HttpClient httpClient)
    : ServiceApiBase(httpClient, "api/Product")
{
    public async Task<ProductDetailDto> GetByKey(int id)
    {
        var respond = await HttpClient.GetAsync($"{Path}/{id}");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<ProductDetailDto>();
        return data ?? throw new RecordNotFound(typeof(ProductDetailDto), id);
    }

    public async Task<IEnumerable<ProductShortDto>> GetAll()
    {
        var respond = await HttpClient.GetAsync($"{Path}");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<IEnumerable<ProductShortDto>>();
        return data ?? [];
    }

    public async Task<IEnumerable<NavCategories>> GetCategories()
    {
        var respond = await HttpClient.GetAsync($"{Path}/categories");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<IEnumerable<NavCategories>>();
        return data ?? [];
    }
}