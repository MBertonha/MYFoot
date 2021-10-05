using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio.Entidades
{
    public interface IGeUsuarioRepositorio
    {
        Task<GE_USUARIO> InsertAsync(GE_USUARIO exemplo);
        Task<GE_USUARIO> UpdateAsync(GE_USUARIO exemplo);
    }
}
