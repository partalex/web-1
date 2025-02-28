using Frontend.Content;
using Frontend.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddLogging();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8000/") });
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