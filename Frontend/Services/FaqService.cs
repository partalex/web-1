using Shared.Models;

namespace Frontend.Services;

public class FaqService(HttpClient httpClient)
    : ServiceApiGet<Faq>(httpClient, "api/Faq")
{
    public async Task<IEnumerable<Faq>> GetAnswered()
    {
        var respond = await HttpClient.GetAsync($"{Path}/available");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<IEnumerable<Faq>>();
        return data ?? [];
    }

    public async Task<bool> Post(Faq faq)
    {
        var respond = await HttpClient.PostAsJsonAsync($"{Path}", faq);
        return respond.IsSuccessStatusCode;
    }
}