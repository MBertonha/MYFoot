using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Localizacao
{
    public class LocalizacaoCaminho
    {
        public static string MensagensErro { get; set; } = "MensagensErro";
        public static string ErroAoBuscarUsuario { get; set; } = "ErroAoBuscarUsuario";
        //Inserir
        public static string ErroAoCadastrar { get; set; } = "ErroAoCadastrar";

        //Atualizar
        public static string EmailNaoCadastrado { get; set; } = "EmailNaoCadastrado";
        public static string ErroAoAtualizar { get; set; } = "ErroAoAtualizar";
        public static string SenhaIncompativel { get; set; } = "SenhaIncompativel";
    }
}
