using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Repositories;

namespace Modelo.Dominio.Entidades
{
    public interface IGeJogadorRepositorio : IRepository
    {
        Task<GE_JOGADOR> InsertAsync(GE_JOGADOR exemplo);
        Task<GE_JOGADOR> UpdateAsync(GE_JOGADOR exemplo);
    }
}
