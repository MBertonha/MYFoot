using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tnf.Configuration;
using Modelo.Infra.BD;
using Modelo.Servico.Servicos;
using Modelo.Servico.AutoMapper;
using Modelo.Aplicacao.Configurações;
using Modelo.Dominio.Localizacao;

namespace MyFoot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            BancoDadosConfig = new PostgreesConfig(configuration);
        }

        public IConfiguration Configuration { get; }
        public PostgreesConfig BancoDadosConfig { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o => o.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson();

            #region CORS
            services.AddCors();
            #endregion

            #region Versionamento
            services.AddVersionamentoConfiguration();
            #endregion

            #region Banco Dados
            services.AddEfCorePostgrees();
            #endregion

            #region Memory Cache
            services.AddMemoryCache();
            #endregion

            #region Classes
            services.AddServicosConfiguracao();
            #endregion

            #region TNF
            services.AddAutoMapperTnf();
            services.AddTnfEntityFrameworkCore();
            services.AddTnfDomain();
            #endregion

            #region Swagger
            services.AddSwaggerConfiguration(Configuration);
            #endregion

            return services.BuildServiceProvider(false);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            #region Swagger
            app.UseSwaggerConfiguration(provider);
            #endregion

            #region TNF
            app.UseTnfAspNetCore(configuration =>
            {
                configuration.UseDomainLocalization();
                configuration.DefaultNameOrConnectionString = "Server=localhost;Port=5432;Database=myFoot;User Id=postgres;Password=postgres;";
                configuration.EnableDevartPostgreSQLDriver();
                configuration.DefaultPageSize(10, 999999);
            });
            #endregion

            #region CORS
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
            #endregion

            app.UseMvc();
        }
    }
}
