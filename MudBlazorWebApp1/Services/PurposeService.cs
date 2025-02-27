using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public class PurposeService(HttpClient httpClient)
    : ServiceApiGet<PurposeDto>(httpClient, "api/Purpose")
{
}