using Shared.Realisations;

namespace Frontend.Services;

public class PatternService(HttpClient httpClient)
    : ServiceApiGet<PurposeDto>(httpClient, "api/Pattern")
{
}