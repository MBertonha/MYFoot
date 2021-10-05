using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Repositories;

namespace Modelo.Dominio.Entidades.Repositorios
{
    public interface IGeDmRepositorio : IRepository
    {
        Task<GE_DM> InsertAsync(GE_DM exemplo);
        Task<GE_DM> UpdateAsync(GE_DM exemplo);
    }
}
