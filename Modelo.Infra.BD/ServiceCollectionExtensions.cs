using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modelo.Infra.BD.Contexto;
using Modelo.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.BD
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCorePostgrees(this IServiceCollection services)
        {
            services.AddEfCore();

            services.AddTnfDbContext<MyFootContexto, PostgreesContexto>(config =>
            {
                config.DbContextOptions.UseNpgsql(config.ConnectionString);
            });

            return services;
        }
    }
}
