﻿using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace Modelo.Dominio.DTO
{
    public class AlterarGe_LoginDTO : BaseDto
    {
        public int SeqLogin { get; set; }
        public string EmailLogin { get; set; }
        public string Senha { get; set; }
        public int TipoUsuario { get; set; }
    }
}