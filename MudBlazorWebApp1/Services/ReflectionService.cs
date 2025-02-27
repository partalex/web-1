using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public class ReflectionService(HttpClient httpClient)
    : ServiceApiGet<PurposeDto>(httpClient, "api/Reflection")
{
}