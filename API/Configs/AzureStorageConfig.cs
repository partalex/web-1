using API.Services;

namespace API.Configs;

public static class AzureStorageConfig
{
    public static void AddAzureStorage(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton(new ServerStorageService(connectionString));
    }
}