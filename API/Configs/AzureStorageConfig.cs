using API.Services.Storage;

namespace API.Configs;

public static class AzureStorageConfig
{
    public static void AddAzureStorage(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton(new AzureStorageService(connectionString));
    }
}