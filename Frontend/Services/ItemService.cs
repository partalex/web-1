using Shared.Realisations;

namespace Frontend.Services;

public class ItemService(HttpClient httpClient)
    : ServiceApiContainer<ItemDto>(httpClient, "api/Item")
{
}