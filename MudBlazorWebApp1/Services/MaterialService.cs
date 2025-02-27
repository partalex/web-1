using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public class MaterialService(HttpClient httpClient)
    : ServiceApiGet<MaterialDto>(httpClient, "api/Material")
{
}