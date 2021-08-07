using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Localizacao
{
    public static class LocalizacaoChaves
    {
        public enum MensagensErro
        {
            MensagensErro,
            ErroAoCadastrar,
            EmailNaoCadastrado,
            ErroAoAtualizar,
            SenhaIncompativel,
            ErroAoBuscarUsuario,
            EmailInvalido,
            StatusInvalido,
            TamanhoEmailInvalido,
            TamanhoSenhaInvalido,
            SenhaFraca,
            NicknameNaoCadastrado
        }
    }
}
