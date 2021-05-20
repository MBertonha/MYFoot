using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace Modelo.Dominio.DTO
{
    public class ListarGe_TimeDTO : BaseDto
    {
        public int SeqTime { get; set; }
        public string NomeTime { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public int TipoPlano { get; set; }
        public string Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
