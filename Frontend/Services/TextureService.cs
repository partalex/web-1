using Shared.Realisations;

namespace Frontend.Services;

public class TextureService(HttpClient httpClient)
    : ServiceApiGet<PurposeDto>(httpClient, "api/Texture")
{
}