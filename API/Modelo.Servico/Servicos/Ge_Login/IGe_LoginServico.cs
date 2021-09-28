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
        Task<ResponseLogin> BuscarUmUsuario(string nickname, string senha);
        Task<AdicionarGE_LoginDTO> Adicionar(AdicionarGE_LoginDTO exemplo);
        Task<AlterarGe_LoginDTO> Atualizar(string email, string senha, Ge_LoginDTO exemploAtualizado);
    }
}
