using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Dto;
using Tnf.Repositories;

namespace Modelo.Dominio.DTO.Interfaces
{
    public interface IGeLoginLeituraRepositorio : IRepository
    {
        Task<IListDto<ListarGe_LoginDTO>> BuscarTodos(BuscarTodosGe_LoginDTO buscarTodos);
        Task<Ge_LoginDTO> BuscarPorId(int seqLogin);
    }
}
