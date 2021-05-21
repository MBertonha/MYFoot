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

        public async Task<AdicionarGE_UsuarioDTO> Adicionar(AdicionarGE_UsuarioDTO exemplo)
        {
            try
            {
                if (!ValidateDto<AdicionarGE_UsuarioDTO>(exemplo)) return null;

                var usuario = await _LeituraRepositorio.BuscarPorNomeUsuario(exemplo.NomeUsuario);
                if (usuario != null)
                {
                    return null;
                }

                var novoObj = exemplo.MapTo<GE_USUARIO>();

                var existeInconsitencia = await VerificaInconsistencias(novoObj);

                if (!existeInconsitencia && EstaValido(novoObj))
                {
                    novoObj = await _Repositorio.InsertAsync(novoObj);
                    if (await Commit())
                    {
                        return novoObj.MapTo<AdicionarGE_UsuarioDTO>();
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

        public async Task<AlterarGe_UsuarioDTO> Atualizar(int sequsuario, Ge_UsuarioDTO model)
        {
            try
            {
                if (!ValidateDto(model)) return null;

                var obj = await _LeituraRepositorio.BuscarPorSeqUsuario(sequsuario);

                if (obj == null)
                {
                    RegistraLog.Log("Usuario não encontrado");
                    return null;
                }

                if (model.SeqUsuario != 0 || model.DataInclusao.ToString() != "01/01/0001 00:00:00" || model.SeqTime != 0 || model.SeqLogin !=0)
                {
                    RegistraLog.Log("Nao e possivel alterar seqUsuario, data de inclusao, seqTime, seqLogin");
                    return null;
                }
                if (model.DataNascimento.ToString() != "01/01/0001 00:00:00")
                {
                    obj.DataNascimento = model.DataNascimento;
                }
                var novomodelo = new AdicionarGE_UsuarioDTO()
                {

                    SeqUsuario = obj.SeqUsuario,
                    DataInclusao = obj.DataInclusao,
                    SeqTime = obj.SeqTime,
                    SeqLogin = obj.SeqLogin,
                    NomeUsuario = model.NomeUsuario.IsNullOrEmpty() ? obj.NomeUsuario : model.NomeUsuario,
                    Email = model.Email.IsNullOrEmpty() ? obj.Email : model.Email,
                    DataNascimento = obj.DataNascimento,
                    Endereco = model.Endereco.IsNullOrEmpty() ? obj.Endereco : model.Endereco,
                    CEP = model.CEP.IsNullOrEmpty() ? obj.CEP : model.CEP,
                    UF = model.UF.IsNullOrEmpty() ? obj.UF : model.UF,
                    Telefone = model.Telefone.IsNullOrEmpty() ? obj.Telefone : model.Telefone,
                    Ativo = model.Ativo.IsNullOrEmpty() ? obj.Ativo : model.Ativo
                };

                var novo = novomodelo.MapTo<GE_USUARIO>();
                var existeInconsitencia = await VerificaInconsistencias(novo);

                if (!existeInconsitencia && EstaValido(novo))
                {
                    novo = await _Repositorio.UpdateAsync(novo);

                    return novo.MapTo<AlterarGe_UsuarioDTO>();
                }

                return null;
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
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

        public async Task<Ge_UsuarioDTO> BuscarUmUsuario(string nomeusuario)
        {
            try
            {

                var usuario = await _LeituraRepositorio.BuscarPorNomeUsuario(nomeusuario);


                if (usuario == null)
                {
                    return null;
                }

                return usuario;

            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
        }

        public async Task<Ge_UsuarioDTO> BuscarUmUsuarioPorSeq(int seqUsuario)
        {
            try
            {

                var usuario = await _LeituraRepositorio.BuscarPorSeqUsuario(seqUsuario);


                if (usuario == null)
                {
                    return null;
                }

                return usuario;

            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
        }

        protected override async Task<bool> VerificaInconsistencias(GE_USUARIO obj)
        {
            ValidacaoGeUsuario _validacao = new ValidacaoGeUsuario(_LeituraRepositorio);

            var ativo = _validacao.ValidaAtivo(obj.Ativo);

            return ativo;
        }
    }
}
