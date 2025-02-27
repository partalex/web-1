namespace API.Configs;

public static class CorsConfig
{
    public static void AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("MyPolicy", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Access-Control-Allow-Origin");
            });
        });
    }

    public static string GetCorsPolicyName()
    {
        return "MyPolicy";
    }
}