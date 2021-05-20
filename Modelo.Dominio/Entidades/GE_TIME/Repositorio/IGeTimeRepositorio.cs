using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Repositories;

namespace Modelo.Dominio.Entidades 
{
    public interface IGeTimeRepositorio : IRepository
    {
        Task<GE_TIME> InsertAsync(GE_TIME exemplo);
        Task<GE_TIME> UpdateAsync(GE_TIME exemplo);
    }
}
