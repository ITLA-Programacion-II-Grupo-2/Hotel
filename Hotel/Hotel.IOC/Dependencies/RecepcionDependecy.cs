
using Hotel.Application.Contract;
using Hotel.Application.Service;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.IOC.Dependencies
{
    public static class RecepcionDependecy
    {
        public static void AddRecepcionDependency(this IServiceCollection services)
        {
            services.AddScoped<IRecepcionRepository, RecepcionRepository>();
            services.AddTransient<IRecepcionService, RecepcionService>();
        }
    }
}
