using Microsoft.Extensions.DependencyInjection;
using Modelo.Servico.AutoMapper.SystemLinq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Servico.AutoMapper
{
    public static class AutoMapperConfiguracao
    {
        public static void AddAutoMapperTnf(this IServiceCollection services)
        {
            services.AddTnfAutoMapper(config =>
            {
                config.AddProfile<MyFootProfile>();
                config.AddProfile<SystemLinqProfile>();
            });
        }
    }
}
