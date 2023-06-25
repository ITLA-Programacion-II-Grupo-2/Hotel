using Microsoft.Extensions.DependencyInjection;
using Hotel.Application.Contract;
using Hotel.Application.Services;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Repositories;


namespace Hotel.IOC.Dependencies
{
    public static class HabitacionDependency
    {
        public static void AddHabitacionDependency(this IServiceCollection services)
        {
            services.AddScoped<IHabitacionRepository, HabitacionRepository>();
            services.AddScoped<IEstadoHabitacionRepository, EstadoHabitacionRepository>();

            services.AddTransient<IHabitacionService, HabitacionService>();

        }
    }
}
