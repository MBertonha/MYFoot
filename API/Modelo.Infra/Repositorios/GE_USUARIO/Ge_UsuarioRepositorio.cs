using Modelo.Dominio.Entidades;
using Modelo.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace Modelo.Infra.Repositorios
{
    public class Ge_UsuarioRepositorio : EfCoreRepositoryBase<MyFootContexto, GE_USUARIO>, IGeUsuarioRepositorio
    {
        public Ge_UsuarioRepositorio(IDbContextProvider<MyFootContexto> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
