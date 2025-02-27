using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public class ItemService(HttpClient httpClient)
    : ServiceApiContainer<ItemDto>(httpClient, "api/Item")
{
}