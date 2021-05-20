using Modelo.Dominio.DTO;
using Modelo.Dominio.Modelos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Servico.Servicos
{
    public interface IGe_TimeServico
    {
        Task<IListaBaseDto<Ge_TimeDTO>> BuscarTodos(BuscarTodosGe_TimeDTO buscarTodos);
        Task<Ge_TimeDTO> BuscarUmTime(string nometime);
        Task<AdicionarGE_TimeDTO> Adicionar(AdicionarGE_TimeDTO exemplo);
        Task<AlterarGe_TimeDTO> Atualizar(int seqtime, Ge_TimeDTO exemploAtualizado);
    }
}
