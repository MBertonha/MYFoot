using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace Modelo.Dominio.DTO
{
    public class AdicionarGE_TimeDTO : BaseDto
    {
    public string NomeTime { get; set; }
    public string CEP { get; set; }
    public string UF { get; set; }
    public int TipoPlano { get; set; }
    public string Ativo { get; set; }
    public DateTime DataInclusao { get; set; }
    public int QtdJogos { get; set; }
    }
}
