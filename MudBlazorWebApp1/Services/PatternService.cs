using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public class PatternService(HttpClient httpClient)
    : ServiceApiGet<PurposeDto>(httpClient, "api/Pattern")
{
}