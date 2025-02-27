using Shared.Realisations;

namespace Frontend.Services;

public class MaterialService(HttpClient httpClient)
    : ServiceApiGet<MaterialDto>(httpClient, "api/Material")
{
}