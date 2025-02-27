namespace Frontend.Services;

public abstract class ServiceApiBase(
    HttpClient httpClient,
    string path)
{
    protected string Path { get; } = path;
    protected HttpClient HttpClient { get; } = httpClient;
}