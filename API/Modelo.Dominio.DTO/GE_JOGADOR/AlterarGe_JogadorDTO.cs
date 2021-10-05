using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace Modelo.Dominio.DTO
{
    public class AlterarGe_JogadorDto : BaseDto
    {
        public int Gols { get; set; }
        public int Ca { get; set; }
        public int Cv { get; set; }
        public int GolsSofridos { get; set; }
        public int JogosJogados { get; set; }
        public string Status { get; set; }
    }
}
