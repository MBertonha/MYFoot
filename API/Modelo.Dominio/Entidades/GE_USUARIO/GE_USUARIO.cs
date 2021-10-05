using Modelo.Dominio.Modelos.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Entidades
{
    public class GE_USUARIO : Entidade<GE_USUARIO>
    {
        #region VARIAVEIS
        public int SeqUsuario {get; private set;}
        public string NomeUsuario { get; private set; }
        public DateTime DtaNascimento { get; private set; }
        public string Endereco { get; private set; }
        public string Cep { get; private set; }
        public string Uf { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Ativo { get; private set; }
        public DateTime DtaInclusao { get; private set; }
        public int SeqTime { get; private set; }
        public int SeqLogin { get; private set; }
        public string Dm { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public string PosicaoPreferencial { get; private set; }
        public string Inadimplente { get; private set;  }

        public GE_USUARIO() { }

        public GE_USUARIO(int seqUsuario, string nomeUsuario, DateTime dtaNascimento, string endereco, string cep, string uf, string telefone, string email, string ativo, DateTime dtaInclusao, int seqTime, int seqLogin, string dm, string cpf, string rg, string inadimplente, string posicao)
        {
            SeqUsuario = seqUsuario;
            NomeUsuario = nomeUsuario;
            DtaNascimento = dtaNascimento;
            Endereco = endereco;
            Cep = cep;
            Uf = uf;
            Telefone = telefone;
            Email = email;
            Ativo = ativo ?? "S";
            DtaInclusao = dtaInclusao;
            SeqTime = seqTime;
            SeqLogin = seqLogin;
            Dm = dm ?? "N";
            Cpf = cpf;
            Rg = rg;
            PosicaoPreferencial = posicao;
            Inadimplente = inadimplente;


            Validar(this);
        }

        public override bool EstaValido()
        {
            return ResultadoValidacao.IsValid;
        }
        #endregion


    }
}
