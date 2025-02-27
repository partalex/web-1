using Shared.Realisations;

namespace Frontend.Services;

public class PurposeService(HttpClient httpClient)
    : ServiceApiGet<PurposeDto>(httpClient, "api/Purpose")
{
}