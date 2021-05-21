using Modelo.Dominio.Modelos.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Entidades
{
    public partial class GE_USUARIO : Entidade<GE_USUARIO>
    {
        #region Variaveis

        public int SeqUsuario { get; private set; }
        public string NomeUsuario { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Endereco { get; private set; }
        public string CEP { get; private set; }
        public string UF { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Ativo { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public int SeqTime { get; private set; }
        public int SeqLogin { get; private set; }

        #endregion

        public GE_USUARIO() { }

        public GE_USUARIO(int seqUsuario, string nomeUsuario, DateTime dataNascimento, string endereco, string cep, string uf, string telefone, string email, string ativo, DateTime dataInclusao, int seqTime, int seqLogin)
        {
            SeqUsuario = seqUsuario;
            NomeUsuario = nomeUsuario;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            CEP = cep;
            UF = uf;
            Telefone = telefone;
            Email = email;
            Ativo = ativo ?? "S";
            DataInclusao = dataInclusao;
            SeqTime = seqTime;
            SeqLogin = seqLogin;


            //Incluir validações


            Validar(this);
        }

        public override bool EstaValido()
        {
            return ResultadoValidacao.IsValid;
        }
    }
}
