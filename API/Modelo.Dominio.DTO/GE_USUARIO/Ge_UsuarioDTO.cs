using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace Modelo.Dominio.DTO
{

    public class Ge_UsuarioDTO : BaseDto
    {
        public int SeqUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public int SeqTime { get; set; }
        public int SeqLogin { get; set; }
    }
}
