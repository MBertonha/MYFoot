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
        Task<Ge_UsuarioDTO> BuscarUmUsuario(string nomeusuario);
        Task<Ge_UsuarioDTO> BuscarUmUsuarioPorSeq(int seqUsuario);
        Task<AdicionarGE_UsuarioDTO> Adicionar(AdicionarGE_UsuarioDTO exemplo);
        Task<AlterarGe_UsuarioDTO> Atualizar(int sequsuario, Ge_UsuarioDTO exemploAtualizado);
    }
}
