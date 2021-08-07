using Modelo.Dominio.Modelos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Repositories;

namespace Modelo.Dominio.DTO.Interfaces
{
    public interface IGeTimeLeituraRepositorio : IRepository
    {
        Task<IListaBaseDto<Ge_TimeDTO>> BuscarTodos(BuscarTodosGe_TimeDTO buscarTodos);
        Task<Ge_TimeDTO> BuscarPorNomeTime(string nometime);
        Task<Ge_TimeDTO> BuscarPorSeqTime(int seqtime);

    }
}
