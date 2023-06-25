
using Hotel.Application.Contract;
using Hotel.Application.Service;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.IOC.Dependencies
{
    public static class RolUsuarioDependency
    {
        public static void AddRolUsuarioDependency(this IServiceCollection services)
        {
            services.AddScoped<IRolUsuarioRepository, RolUsuarioRepository>();
            services.AddTransient<IRolUsuarioService, RolUsuarioService>();
        }
    }
}
