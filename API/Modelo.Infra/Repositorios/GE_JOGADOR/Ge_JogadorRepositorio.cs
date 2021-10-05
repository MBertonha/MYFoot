using Modelo.Dominio.Entidades;
using Modelo.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace Modelo.Infra.Repositorios
{
    public class Ge_JogadorRepositorio : EfCoreRepositoryBase<MyFootContexto, GE_JOGADOR>, IGeJogadorRepositorio
    {
        public Ge_JogadorRepositorio(IDbContextProvider<MyFootContexto> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
