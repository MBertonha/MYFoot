using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services)
        {
            //services.AddTransient<IExemploRepositorio, ExemploRepositorio>();
            //services.AddTransient<IExemploLeituraRepositorio, ExemploLeituraRepositorio>();

            return services;
        }
    }
}
