using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Localizacao
{
    public class LocalizacaoCaminho
    {
        public static string MensagensErro { get; } = "MensagensErro";
        public static string ErroAoBuscarUsuario { get; set; } = "ErroAoBuscarUsuario";
        public static string ErroAoCadastrar { get; set; } = "ErroAoCadastrar";
        public static string EmailNaoCadastrado { get; set; } = "EmailNaoCadastrado";
        public static string ErroAoAtualizar { get; set; } = "ErroAoAtualizar";
        public static string SenhaIncompativel { get; set; } = "SenhaIncompativel";
        public static string StatusInvalido { get; set; } = "StatusInvalido";
        public static string EmailInvalido { get; set; } = "EmailInvalido";
        public static string TamanhoEmailInvalido { get; set; } = "TamanhoEmailInvalido";
        public static string TamanhoSenhaInvalido { get; set; } = "TamanhoSenhaInvalido";
        public static string SenhaFraca { get; set; } = "SenhaFraca";
        public static string NicknameNaoCadastrado { get; set; } = "NicknameNaoCadastrado";

    }
}
