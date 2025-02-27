using Shared.Realisations;

namespace Frontend.Services;

public class ReflectionService(HttpClient httpClient)
    : ServiceApiGet<PurposeDto>(httpClient, "api/Reflection")
{
}