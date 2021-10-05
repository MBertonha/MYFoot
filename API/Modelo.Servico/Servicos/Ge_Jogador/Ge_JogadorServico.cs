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
    public class Ge_JogadorServico : ServicoBase<GE_JOGADOR>, IGe_JogadorServico
    {
        private readonly INotificationHandler _controleNotificacao;
        private readonly IUnitOfWorkManager _controleTransacao;
        private readonly IGeJogadorRepositorio _Repositorio;
        private readonly IGeJogadorLeituraRepositorio _LeituraRepositorio;

        public Ge_JogadorServico(
           INotificationHandler controleNotificacao,
           IUnitOfWorkManager controleTransacao,
           IGeJogadorRepositorio repositorio,
           IGeJogadorLeituraRepositorio leituraRepositorio
       ) : base(controleNotificacao, controleTransacao)
        {
            _controleTransacao = controleTransacao;
            _controleNotificacao = controleNotificacao;
            _Repositorio = repositorio;
            _LeituraRepositorio = leituraRepositorio;
        }

        public async Task<AdicionarGe_JogadorDto> Adicionar(AdicionarGe_JogadorDto exemplo)
        {
            throw new NotImplementedException();
        }

        public async Task<AlterarGe_JogadorDto> Atualizar(int seqJogador, Ge_JogadorDTO exemploAtualizado)
        {
            throw new NotImplementedException();
        }

        public async Task<IListaBaseDto<Ge_JogadorDTO>> BuscarTodos(BuscarTodosGe_JogadorDTO buscarTodos)
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

        protected override async Task<bool> VerificaInconsistencias(GE_JOGADOR obj)
        {
            return false;
        }
    }
}
