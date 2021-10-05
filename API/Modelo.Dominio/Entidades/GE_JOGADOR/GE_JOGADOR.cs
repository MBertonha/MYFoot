using Modelo.Dominio.Modelos.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio.Entidades
{
    public class GE_JOGADOR : Entidade<GE_JOGADOR>
    {
        public int SeqJogador { get; private set; }
        public int SeqUsuario { get; private set; }
        public int Gols { get; private set; }
        public int Ca { get; private set; }
        public int Cv { get; private set; }
        public int GolsSofridos { get; private set; }
        public int JogosJogados { get; private set; }
        public string Status { get; private set; }

        public GE_JOGADOR() { }
        public GE_JOGADOR(int seqJogador, int seqUsuario, int gols, int ca, int cv, int golsSofridos, int jogosJogados, string status)
        {
            SeqJogador = seqJogador;
            SeqUsuario = seqUsuario;
            Gols = gols;
            Ca = ca;
            Cv = cv;
            GolsSofridos = golsSofridos;
            JogosJogados = jogosJogados;
            Status = status;

            Validar(this);
        }

        public override bool EstaValido()
        {
            return ResultadoValidacao.IsValid;
        }
    }
}
