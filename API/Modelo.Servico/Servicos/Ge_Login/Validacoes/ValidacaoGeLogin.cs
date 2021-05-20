using Modelo.Dominio.Localizacao;
using Modelo.Servico.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tnf.Notifications;

namespace Modelo.Servico.Servicos
{
    public class ValidacaoGeLogin
    {
        private readonly INotificationHandler _controleNotificacao;
        public ValidacaoGeLogin(INotificationHandler controleNotificacao) 
        {
            _controleNotificacao = controleNotificacao;
        }


        public bool ValidaEmail(string email)
        {
            if(email.Length > 30)
            {
                //_controleNotificacao.RaiseError(LocalizacaoCaminho.MensagensErro, LocalizacaoChaves.MensagensErro.TamanhoEmailInvalido);
                return true;
            }

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!rg.IsMatch(email))
            {
                //_controleNotificacao.RaiseError(LocalizacaoCaminho.MensagensErro, LocalizacaoChaves.MensagensErro.EmailInvalido);
                return true;
            }

            return false;
        }
        public bool ValidaStatus(string status)
        {
            if(status != "S" && status != "N")
            {
                //_controleNotificacao.RaiseError(LocalizacaoCaminho.MensagensErro, LocalizacaoChaves.MensagensErro.StatusInvalido);
                return true;
            }
            return false;
        }

        public bool ValidaSenha(string senha)
        {
            ValidarSenha _validarSenha = new ValidarSenha();

            var pontosSenha = _validarSenha.geraPontosSenha(senha);
            if (pontosSenha < 40)
            {
                //_controleNotificacao.RaiseError(LocalizacaoCaminho.MensagensErro, LocalizacaoChaves.MensagensErro.SenhaFraca);
                return true;
            }

            if (senha.Length > 10 || senha.Length < 6)
            {
                //_controleNotificacao.RaiseError(LocalizacaoCaminho.MensagensErro, LocalizacaoChaves.MensagensErro.TamanhoSenhaInvalido);
                return true;
            }

            return false;
        }
    }
}
