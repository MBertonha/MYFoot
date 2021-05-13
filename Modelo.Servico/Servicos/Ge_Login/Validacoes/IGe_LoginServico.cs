using Modelo.Dominio.DTO;
using Modelo.Dominio.Modelos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Servico.Servicos
{
    public interface IGe_LoginServico
    {
        Task<IListaBaseDto<Ge_LoginDTO>> BuscarTodos(BuscarTodosGe_LoginDTO buscarTodos);
        Task<Ge_LoginDTO> BuscarPorId(int id);
        Task<AdicionarGE_LoginDTO> Adicionar(AdicionarGE_LoginDTO exemplo);
        Task<AlterarGe_LoginDTO> Atualizar(int id, Ge_LoginDTO exemploAtualizado);
    }
}
