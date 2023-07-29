using Hotel.Application.Contract;
using Hotel.Application.Service;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.IOC.Dependencies
{
    public static class ClienteDependency
    {
        public static void AddClienteDependency(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteService, ClienteService>();
        }
    }
}

