using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Modelo.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tnf.Drivers.DevartPostgreSQL;
using Tnf.Runtime.Session;

namespace Modelo.Infra.BD.Fabrica
{
    public class MyFootFabrica : IDesignTimeDbContextFactory<MyFootContexto>
    {
        public MyFootContexto CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyFootContexto>();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            builder.UseNpgsql(connectionString);
            PostgreSqlLicense.Validate(connectionString);

            return new MyFootContexto(builder.Options, NullTnfSession.Instance);
        }
    }
}
