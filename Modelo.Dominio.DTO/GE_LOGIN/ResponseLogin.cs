using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace Modelo.Dominio.DTO
{
    public class ResponseLogin : BaseDto
    {
        public int Num { get; set; }
        public string Valido { get; set; }
    }
}
