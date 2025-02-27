using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public class TextureService(HttpClient httpClient)
    : ServiceApiGet<PurposeDto>(httpClient, "api/Texture")
{
}