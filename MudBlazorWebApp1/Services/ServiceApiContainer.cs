using MudBlazorWebApp1.Exceptions;
using Shared.Realisations;

namespace MudBlazorWebApp1.Services;

public abstract class ServiceApiContainer<T>(
    HttpClient httpClient,
    string path)
    : ServiceApiBase(httpClient, path)
{
    public async Task<Container<T>> GetContainer()
    {
        var respond = await HttpClient.GetAsync($"{Path}/container");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<Container<T>>();
        return data ?? throw new RecordNotFound(typeof(Container<T>), 0);
    }
}