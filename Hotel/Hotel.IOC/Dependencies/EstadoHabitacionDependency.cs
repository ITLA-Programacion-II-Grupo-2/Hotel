using Microsoft.Extensions.DependencyInjection;
using Hotel.Application.Contract;
using Hotel.Application.Services;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Repositories;

namespace Hotel.IOC.Dependencies
{
    public static class EstadoHabitacionDependency
    {
        public static void AddEstadoHabitacionDependency(this IServiceCollection services)
        {
            services.AddScoped<IEstadoHabitacionRepository, EstadoHabitacionRepository>();
            services.AddScoped<IHabitacionRepository, HabitacionRepository>();

            services.AddTransient<IEstadoHabitacionService, EstadoHabitacionService>();

        }
    }
}
