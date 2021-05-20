using Modelo.Dominio.Entidades;
using Modelo.Infra.Contexto;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace Modelo.Infra.Repositorios
{
    public class Ge_LoginRepositorio : EfCoreRepositoryBase<MyFootContexto, GE_LOGIN>, IGeLoginRepositorio
    {
        public Ge_LoginRepositorio(IDbContextProvider<MyFootContexto> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
