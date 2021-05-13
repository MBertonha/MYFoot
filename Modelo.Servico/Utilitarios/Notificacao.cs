using Modelo.Dominio.Localizacao;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Notifications;

namespace Modelo.Servico.Utilitarios
{
    public static class Notificacao
    {
        public static void AdicionarNotificacao(INotificationHandler controleNotificacao, string identificadorNotificacao)
        {
            controleNotificacao.Raise(
                controleNotificacao.DefaultBuilder
                    .WithCode("400")
                    .WithBadRequestStatus()
                    .WithMessage(LocalizacaoCaminho.MensagensErro, (LocalizacaoChave.MensagensErro)Enum.Parse(typeof(LocalizacaoChave.MensagensErro), identificadorNotificacao))
                    .WithDetailedMessage(LocalizacaoCaminho.MensagensErro, (LocalizacaoChave.MensagensErro)Enum.Parse(typeof(LocalizacaoChave.MensagensErro), identificadorNotificacao))
                    .AsError()
                    .Build());
        }
    }
}
