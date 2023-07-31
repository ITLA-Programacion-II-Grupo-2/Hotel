using Hotel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Hotel.IOC.Dependencies;
using Hotel.Web.Api.ApiServices;
using Hotel.Web.Api;
using Hotel.Web.Api.ApiServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database dependency registry
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));

// My Dependencies
builder.Services.AddUsuarioDependency();
builder.Services.AddRolUsuarioDependency();
builder.Services.AddRecepcionDependency();

builder.Services.AddTransient<IUsuarioApiService, UsuarioApiService>();
builder.Services.AddTransient<IRolUsuarioApiService, RolUsuarioApiService>();
builder.Services.AddTransient<IRecepcionApiService, RecepcionApiService>();

builder.Services.AddTransient<IApiCaller, ApiCaller>();

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
