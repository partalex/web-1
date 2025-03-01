using Frontend.Content;
using Frontend.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddLogging();
// var apiUrl = builder.Configuration.GetValue<string>("ApiUrl")!;
const string apiUrl = "http://localhost:8000";
// const string apiUrl = "http://api:8080";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ClientStorageService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<FaqService>();
builder.Services.AddScoped<ManufacturerService>();
builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<GalleryService>();
builder.Services.AddScoped<DecorService>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Error", createScopeForErrors: true);


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();