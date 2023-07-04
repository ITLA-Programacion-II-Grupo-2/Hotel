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
    public static class PisoDeoendency
    {
        public static void AddPisooDependency(this IServiceCollection services)
        {
            services.AddScoped<IPisoRepository, PisoRepository>();
            services.AddTransient<IPisoServece, PisoService>();
        }


    }
}
