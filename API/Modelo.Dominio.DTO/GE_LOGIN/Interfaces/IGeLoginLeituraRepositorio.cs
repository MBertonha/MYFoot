using Modelo.Dominio.Modelos.Dtos;
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
        Task<IListaBaseDto<Ge_LoginDTO>> BuscarTodos(BuscarTodosGe_LoginDTO buscarTodos);
        Task<Ge_LoginDTO> BuscarPorEmail(string email);
        Task<Ge_LoginDTO> BuscarPorNickname(string nickname);

    }
}
