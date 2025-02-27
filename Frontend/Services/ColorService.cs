using Shared.Realisations;

namespace Frontend.Services;

public class ColorService(HttpClient httpClient)
    : ServiceApiGet<PurposeDto>(httpClient, "api/Color")
{
}