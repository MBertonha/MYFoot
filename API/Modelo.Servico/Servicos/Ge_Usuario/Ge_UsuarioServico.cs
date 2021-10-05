using Modelo.Dominio.DTO;
using Modelo.Dominio.DTO.Interfaces;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Modelos.Dtos;
using Modelo.Servico.Modelos;
using Modelo.Servico.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Notifications;
using Tnf.Repositories.Uow;

namespace Modelo.Servico.Servicos
{
    public class Ge_UsuarioServico : ServicoBase<GE_USUARIO>, IGe_UsuarioServico
    {
        private readonly INotificationHandler _controleNotificacao;
        private readonly IUnitOfWorkManager _controleTransacao;
        private readonly IGeUsuarioRepositorio _Repositorio;
        private readonly IGeUsuarioLeituraRepositorio _LeituraRepositorio;

        public Ge_UsuarioServico(
           INotificationHandler controleNotificacao,
           IUnitOfWorkManager controleTransacao,
           IGeUsuarioRepositorio repositorio,
           IGeUsuarioLeituraRepositorio leituraRepositorio
       ) : base(controleNotificacao, controleTransacao)
        {
            _controleTransacao = controleTransacao;
            _controleNotificacao = controleNotificacao;
            _Repositorio = repositorio;
            _LeituraRepositorio = leituraRepositorio;
        }

        public async Task<AdicionarGe_UsuarioDTO> Adicionar(AdicionarGe_UsuarioDTO exemplo)
        {
            try
            {
                if (!ValidateDto<AdicionarGe_UsuarioDTO>(exemplo)) return null;

                var novoObj = exemplo.MapTo<GE_USUARIO>();

                var existeInconsitencia = await VerificaInconsistencias(novoObj);
                var novoExemplo = exemplo.MapTo<GE_USUARIO>();

                if (!existeInconsitencia && EstaValido(novoExemplo))
                {
                    novoExemplo = await _Repositorio.InsertAsync(novoExemplo);
                    if (await Commit())
                    {
                        return novoExemplo.MapTo<AdicionarGe_UsuarioDTO>();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                //_controleNotificacao.RaiseError(LocalizacaoCaminho.MensagensErro, LocalizacaoChaves.MensagensErro.ErroAoCadastrar);
                return null;
            }
        }

        public async Task<AlterarGe_UsuarioDTO> Atualizar(int seqUsuario, Ge_UsuarioDTO exemploAtualizado)
        {
            throw new NotImplementedException();
        }

        public async Task<IListaBaseDto<Ge_UsuarioDTO>> BuscarTodos(BuscarTodosGe_UsuarioDTO buscarTodos)
        {
            try
            {
                return await _LeituraRepositorio.BuscarTodos(buscarTodos);
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
        }

        protected override async Task<bool> VerificaInconsistencias(GE_USUARIO obj)
        {
            return false;
        }
    }
}
