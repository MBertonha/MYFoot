using Modelo.Dominio.Modelos.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Entidades
{
    public partial class GE_TIME : Entidade<GE_TIME>
    {
        #region Variaveis

        public int SeqTime { get; private set; }
        public string NomeTime { get; private set; }
        public string CEP { get; private set; }
        public string UF { get; private set; }
        public int TipoPlano { get; private set; }
        public string Ativo { get; private set; }
        public DateTime DataInclusao { get; private set; }

        #endregion

        public GE_TIME() { }

        public GE_TIME(int seqTime, string nomeTime, string cep, string uf, int tipoPlano, string ativo, DateTime dataInclusao)
        {
            SeqTime = seqTime;
            NomeTime = nomeTime;
            CEP = cep;
            UF = uf;
            TipoPlano = tipoPlano;
            Ativo = ativo ?? "S";
            DataInclusao = dataInclusao;


            //Incluir validações


            Validar(this);
        }

        public override bool EstaValido()
        {
            return ResultadoValidacao.IsValid;
        }
    }
}
