﻿using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace Modelo.Dominio.DTO
{
    public class BuscarTodosGe_DmDto : RequestAllDto
    {
        public int[] SeqDm { get; set; }
        public DateTime DtaEntrada { get; set; }
        public DateTime DtaSaida { get; set; }
        public int[] Sequsuario { get; set; }
        public string Filter { get; set; }
    }
}