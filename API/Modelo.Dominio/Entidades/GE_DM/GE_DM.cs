using Modelo.Dominio.Modelos.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Entidades
{
    public class GE_DM : Entidade<GE_DM>
    {
        public int SeqDm { get; private set; }
        public DateTime DtaEntrada { get; private set; }
        public DateTime DtaSaida { get; private set; }
        public int Sequsuario { get; private set; }

        public GE_DM(){}

        public GE_DM(int seqDm, DateTime dtaEntrada, DateTime dtaSaida, int sequsuario)
        {
            SeqDm = seqDm;
            DtaEntrada = dtaEntrada;
            DtaSaida = dtaSaida;
            Sequsuario = sequsuario;
        }

        public override bool EstaValido()
        {
            return ResultadoValidacao.IsValid;
        }
    }
}
