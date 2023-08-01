using Hotel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Hotel.IOC.Dependencies;
using Hotel.Web.Api;
using Hotel.Web.Api.ApiService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database dependency registry
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));

// My Dependencies
builder.Services.AddCategoriaDependency();
builder.Services.AddPisoDependency();

builder.Services.AddTransient<ICategoriaApiService, CategoriaApiService>();
builder.Services.AddTransient<IPisoApiService, PisoApiService>();

builder.Services.AddTransient<IApicaller, Apicaller>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();   

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
