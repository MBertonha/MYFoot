using Modelo.Dominio.Entidades;
using Modelo.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace Modelo.Infra.Repositorios
{
    public class Ge_TimeRepositorio : EfCoreRepositoryBase<MyFootContexto, GE_TIME>, IGeTimeRepositorio
    {
        public Ge_TimeRepositorio(IDbContextProvider<MyFootContexto> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
