using Hotel.Application.Contract;
using Hotel.Application.Service;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.IOC.Dependencies
{
    public static class CategoriaDependency 
    {
        public static void AddCategoriaDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<ICategoriaService, CategoriaService>();

        }

    }  
}
