global using MarketApp.Services.MarketService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<MarketService>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MarketService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
