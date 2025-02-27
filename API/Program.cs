using API;
using API.Configs;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using API;
using API.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCorsPolicy();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    // options.UseNpgsql(builder.Configuration.GetConnectionString("AmazonPSQL")));
    options.UseNpgsql(builder.Configuration.GetConnectionString("AmazonPSQL2")));

builder.Services.AddJwtAuthentication(builder.Configuration["JwtSecretKey"]!);
builder.Services.AddAzureStorage(builder.Configuration.GetConnectionString("AzureStorage")!);
// builder.Services.AddAzureStorage(builder.Configuration.GetConnectionString("AzureWindows")!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors(CorsConfig.GetCorsPolicyName());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// if (app.Environment.IsDevelopment())
// {
// app.Urls.Add("http://0.0.0.0:8080");
// }
app.MapGet("/", () => "Hello from API!");

app.Run();