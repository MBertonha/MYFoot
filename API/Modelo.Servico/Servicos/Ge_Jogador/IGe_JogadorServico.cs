using Modelo.Dominio.DTO;
using Modelo.Dominio.Modelos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Servico.Servicos
{
    public interface IGe_JogadorServico
    {
        Task<IListaBaseDto<Ge_JogadorDTO>> BuscarTodos(BuscarTodosGe_JogadorDTO buscarTodos);
        Task<AdicionarGe_JogadorDto> Adicionar(AdicionarGe_JogadorDto exemplo);
        Task<AlterarGe_JogadorDto> Atualizar(int seqJogador, Ge_JogadorDTO exemploAtualizado);
    }
}
