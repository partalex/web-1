using Frontend.Exceptions;

namespace Frontend.Services;

public abstract class ServiceApiGet<T>(
    HttpClient httpClient,
    string path)
    : ServiceApiBase(httpClient, path)
{
    public virtual async Task<T> GetByKey(int id)
    {
        var respond = await HttpClient.GetAsync($"{Path}/{id}");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<T>();
        return data ?? throw new RecordNotFound(typeof(T), id);
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        var respond = await HttpClient.GetAsync($"{Path}");
        respond.EnsureSuccessStatusCode();
        var data = await respond.Content.ReadFromJsonAsync<IEnumerable<T>>();
        return data ?? [];
    }
}