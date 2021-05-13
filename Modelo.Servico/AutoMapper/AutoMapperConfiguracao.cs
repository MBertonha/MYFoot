using Microsoft.Extensions.DependencyInjection;
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
                //config.AddProfile<DominioParaDtoProfile>();
                //config.AddProfile<DtoParaDominioProfile>();
            });
        }
    }
}
