using Modelo.Dominio.Modelos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Repositories;

namespace Modelo.Dominio.DTO.Interfaces
{
    public interface IGe_DmLeituraRepositorio : IRepository
    {
        Task<IListaBaseDto<Ge_DmDto>> BuscarTodos(BuscarTodosGe_DmDto buscarTodos);
    }
}
