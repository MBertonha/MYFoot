using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Localizacao
{
    public class LocalizacaoCaminho
    {
        public static string MensagensErro { get; set; } = "MensagensErro";
        //Inserir
        public static string ErroAoCadastrar { get; set; } = "ErroAoCadastrar";

        //Atualizar
        public static string EmailNaoCadastrado { get; set; } = "EmailNaoCadastrado";
        public static string ErroAoAtualizar { get; set; } = "ErroAoAtualizar";
    }
}
