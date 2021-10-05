using Modelo.Dominio.DTO;
using Modelo.Dominio.Modelos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Servico.Servicos
{
    public interface IGe_UsuarioServico
    {
        Task<IListaBaseDto<Ge_UsuarioDTO>> BuscarTodos(BuscarTodosGe_UsuarioDTO buscarTodos);
        Task<AdicionarGe_UsuarioDTO> Adicionar(AdicionarGe_UsuarioDTO exemplo);
        Task<AlterarGe_UsuarioDTO> Atualizar(int seqUsuario, Ge_UsuarioDTO exemploAtualizado);
    }
}
