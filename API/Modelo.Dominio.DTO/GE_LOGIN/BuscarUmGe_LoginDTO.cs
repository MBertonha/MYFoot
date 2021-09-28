using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace Modelo.Dominio.DTO
{
    public class BuscarUmGe_LoginDTO : BaseDto
    {
        public int SeqLogin { get; set; }
        public string EmailLogin { get; set; }
        public int TipoUsuario { get; set; }
        public bool Habilitado { get; set; }
        public string MensagemErro { get; set; }
    }
}
