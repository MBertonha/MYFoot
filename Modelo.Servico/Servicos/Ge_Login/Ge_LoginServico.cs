using Modelo.Dominio.DTO;
using Modelo.Dominio.DTO.Interfaces;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Localizacao;
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
    public class Ge_LoginServico : ServicoBase<GE_LOGIN>, IGe_LoginServico
    {
        private readonly INotificationHandler _controleNotificacao;
        private readonly IUnitOfWorkManager _controleTransacao;
        private readonly IGeLoginRepositorio _Repositorio;
        private readonly IGeLoginLeituraRepositorio _LeituraRepositorio;

        public Ge_LoginServico(
           INotificationHandler controleNotificacao,
           IUnitOfWorkManager controleTransacao,
           IGeLoginRepositorio repositorio,
           IGeLoginLeituraRepositorio leituraRepositorio
       ) : base(controleNotificacao, controleTransacao)
        {
            _controleTransacao = controleTransacao;
            _controleNotificacao = controleNotificacao;
            _Repositorio = repositorio;
            _LeituraRepositorio = leituraRepositorio;
        }

        public async Task<AdicionarGE_LoginDTO> Adicionar(AdicionarGE_LoginDTO exemplo)
        {
            try
            {
                if (!ValidateDto<AdicionarGE_LoginDTO>(exemplo)) return null;

                exemplo.Senha = Criptografar.CriptografarSenha(exemplo.Senha);

                var novoExemplo = exemplo.MapTo<GE_LOGIN>();

                var existeInconsitencia = await VerificaInconsistencias(novoExemplo);

                if (!existeInconsitencia && EstaValido(novoExemplo))
                {
                    novoExemplo = await _Repositorio.InsertAsync(novoExemplo);
                    if (await Commit())
                    {
                        return novoExemplo.MapTo<AdicionarGE_LoginDTO>();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Notificacao.AdicionarNotificacao(_controleNotificacao, LocalizacaoCaminho.ErroAoCadastrar);
                return null;
            }
           
        }

        public async Task<AlterarGe_LoginDTO> Atualizar(string email, string senha,  Ge_LoginDTO model)
        {
            try
            {
                if (!ValidateDto(model)) return null;

                var obj = await _LeituraRepositorio.BuscarPorEmail(email);
                var senhaDescrp = Criptografar.DescriptografarSenha(senha);

                if (obj == null)
                {
                    Notificacao.AdicionarNotificacao(_controleNotificacao, LocalizacaoCaminho.EmailNaoCadastrado);
                    return null;
                }

                if (senhaDescrp != obj.Senha)
                {
                    Notificacao.AdicionarNotificacao(_controleNotificacao, LocalizacaoCaminho.SenhaIncompativel);
                    return null;
                }

                if (!model.Senha.IsNullOrEmpty()){
                    model.Senha = Criptografar.CriptografarSenha(model.Senha);
                }

                var novoModel = new AlterarGe_LoginDTO()
                {
                    SeqLogin = obj.SeqLogin,
                    EmailLogin = model.EmailLogin.IsNullOrEmpty() ? obj.EmailLogin : model.EmailLogin,
                    Senha = model.Senha.IsNullOrEmpty() ? obj.Senha : model.Senha,
                    TipoUsuario = model.TipoUsuario.Equals(null) ? obj.TipoUsuario : model.TipoUsuario,
                    Ativo = model.Ativo.IsNullOrEmpty() ? obj.Ativo : model.Ativo

                };

                var novo = novoModel.MapTo<GE_LOGIN>();
                var existeInconsitencia = await VerificaInconsistencias(novo);

                if (!existeInconsitencia && EstaValido(novo))
                {
                    novo = await _Repositorio.UpdateAsync(novo);

                    return novo.MapTo<AlterarGe_LoginDTO>();
                }

                return null;
            }
            catch (Exception ex)
            {
                Notificacao.AdicionarNotificacao(_controleNotificacao, LocalizacaoCaminho.ErroAoAtualizar);
                return null;
            }
        }


        public async Task<IListaBaseDto<Ge_LoginDTO>> BuscarTodos(BuscarTodosGe_LoginDTO buscarTodos)
        {
            return await _LeituraRepositorio.BuscarTodos(buscarTodos);
        }

        public async Task<BuscarUmGe_LoginDTO> BuscarUmUsuario(string email, string senha)
        {
            try
            {

                var obj = await _LeituraRepositorio.BuscarPorEmail(email);
                var senhaDescrp = Criptografar.DescriptografarSenha(senha);
                

                if (obj == null)
                {
                    Notificacao.AdicionarNotificacao(_controleNotificacao, LocalizacaoCaminho.EmailNaoCadastrado);
                    return null;
                }

                if (senhaDescrp != obj.Senha)
                {
                    Notificacao.AdicionarNotificacao(_controleNotificacao, LocalizacaoCaminho.SenhaIncompativel);
                    return null;
                }

                var habilitatoAux = true;
                if (obj.Ativo == "N")
                {
                    habilitatoAux = false;
                }

                var novoExemplo = new BuscarUmGe_LoginDTO()
                {
                    SeqLogin = obj.SeqLogin,
                    EmailLogin = obj.EmailLogin,
                    TipoUsuario = obj.TipoUsuario,
                    Habilitado = true
                };

                return novoExemplo;

            }
            catch(Exception ex)
            {
                Notificacao.AdicionarNotificacao(_controleNotificacao, LocalizacaoCaminho.ErroAoBuscarUsuario);
                return null;
            }
        }

        protected override async Task<bool> VerificaInconsistencias(GE_LOGIN obj)
        {
            return false;
        }
    }
}
