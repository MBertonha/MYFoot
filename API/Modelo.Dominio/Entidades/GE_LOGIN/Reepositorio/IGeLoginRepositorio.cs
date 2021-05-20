using System.Threading.Tasks;
using Tnf.Repositories;

namespace Modelo.Dominio.Entidades
{
    public interface IGeLoginRepositorio : IRepository
    {
        Task<GE_LOGIN> InsertAsync(GE_LOGIN exemplo);
        Task<GE_LOGIN> UpdateAsync(GE_LOGIN exemplo);
    }
}
