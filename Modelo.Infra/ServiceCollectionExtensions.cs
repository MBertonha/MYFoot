using Microsoft.Extensions.DependencyInjection;
using Modelo.Dominio.DTO.Interfaces;
using Modelo.Dominio.Entidades;
using Modelo.Infra.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services)
        {
            services.AddTransient<IGeLoginRepositorio, Ge_LoginRepositorio>();
            services.AddTransient<IGeLoginLeituraRepositorio, Ge_LoginLeituraRepositorio>();
            services.AddTransient<IGeTimeRepositorio, Ge_TimeRepositorio>();
            services.AddTransient<IGeTimeLeituraRepositorio, Ge_TimeLeituraRepositorio>();

            return services;
        }
    }
}
