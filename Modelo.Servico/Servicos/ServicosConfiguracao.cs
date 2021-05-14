using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Servico.Servicos
{
    public static class ServicosConfiguracao
    {
        public static void AddServicosConfiguracao(this IServiceCollection services)
        {
            services.AddTransient<IGe_LoginServico, Ge_LoginServico>();
        }
    }
}
