using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public class ColorService(HttpClient httpClient)
    : ServiceApiGet<PurposeDto>(httpClient, "api/Color")
{
}