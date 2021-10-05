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
    public class Ge_TimeServico : ServicoBase<GE_TIME>, IGe_TimeServico
    {
        private readonly INotificationHandler _controleNotificacao;
        private readonly IUnitOfWorkManager _controleTransacao;
        private readonly IGeTimeRepositorio _Repositorio;
        private readonly IGeTimeLeituraRepositorio _LeituraRepositorio;

        public Ge_TimeServico(
           INotificationHandler controleNotificacao,
           IUnitOfWorkManager controleTransacao,
           IGeTimeRepositorio repositorio,
           IGeTimeLeituraRepositorio leituraRepositorio
       ) : base(controleNotificacao, controleTransacao)
        {
            _controleTransacao = controleTransacao;
            _controleNotificacao = controleNotificacao;
            _Repositorio = repositorio;
            _LeituraRepositorio = leituraRepositorio;
        }

        public async Task<AdicionarGE_TimeDTO> Adicionar(AdicionarGE_TimeDTO exemplo)
        {
            try
            {
                if (!ValidateDto<AdicionarGE_TimeDTO>(exemplo)) return null;

                var time = await _LeituraRepositorio.BuscarPorNomeTime(exemplo.NomeTime);
                if (time != null)
                {
                    return null;
                }

                var novoObj = exemplo.MapTo<GE_TIME>();

                var existeInconsitencia = await VerificaInconsistencias(novoObj);

                if (!existeInconsitencia && EstaValido(novoObj))
                {
                    novoObj = await _Repositorio.InsertAsync(novoObj);
                    if (await Commit())
                    {
                        return novoObj.MapTo<AdicionarGE_TimeDTO>();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }

        }

        public async Task<AlterarGe_TimeDTO> Atualizar(int seqtime, Ge_TimeDTO model)
        {
            try
            {
                if (!ValidateDto(model)) return null;

                var obj = await _LeituraRepositorio.BuscarPorSeqTime(seqtime);

                if (obj == null)
                {
                    RegistraLog.Log("Time não encontrado");
                    return null;
                }

                if (model.SeqTime != 0 || model.TipoPlano != 0 || model.DataInclusao.ToString() != "01/01/0001 00:00:00")
                {
                    RegistraLog.Log("Nao e possivel alterar seqTime, data de inclusao, tipo do plano");
                    return null;
                }

                var novomodelo = new AdicionarGE_TimeDTO()
                {
                    TipoPlano = obj.TipoPlano,
                    DataInclusao = obj.DataInclusao,
                    NomeTime = model.NomeTime.IsNullOrEmpty() ? obj.NomeTime : model.NomeTime,
                    CEP = model.CEP.IsNullOrEmpty() ? obj.CEP : model.CEP,
                    UF = model.UF.IsNullOrEmpty() ? obj.UF : model.UF,
                    Ativo = model.Ativo.IsNullOrEmpty() ? obj.Ativo : model.Ativo
                };

                var novo =  novomodelo.MapTo<GE_TIME>();
                var existeInconsitencia = await VerificaInconsistencias(novo);

                if (!existeInconsitencia && EstaValido(novo))
                {
                    novo = await _Repositorio.UpdateAsync(novo);

                    return novo.MapTo<AlterarGe_TimeDTO>();
                }

                return null;
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                //_controleNotificacao.RaiseError(LocalizacaoCaminho.MensagensErro, LocalizacaoChaves.MensagensErro.ErroAoAtualizar);
                return null;
            }
        }

        public async Task<IListaBaseDto<Ge_TimeDTO>> BuscarTodos(BuscarTodosGe_TimeDTO buscarTodos)
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

        public async Task<Ge_TimeDTO> BuscarUmTime(string nometime)
        {
            try
            {

                var time = await _LeituraRepositorio.BuscarPorNomeTime(nometime);


                if (time == null)
                {
                    return null;
                }

                return time;

            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
        }

        protected override async Task<bool> VerificaInconsistencias(GE_TIME obj)
        {
            ValidacaoGeTime _validacao = new ValidacaoGeTime(_LeituraRepositorio);

            var tipo = _validacao.ValidaTipoPlano(obj.TipoPlano);
            var ativo = _validacao.ValidaAtivo(obj.Ativo);

            return tipo || ativo;
        }
    }
}
