using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace Modelo.Dominio.DTO
{
    public class BuscarTodosGe_UsuarioDTO : RequestAllDto
    {
        public int[] SeqUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DtaNascimento { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Ativo { get; set; }
        public DateTime DtaInclusao { get; set; }
        public int[] SeqTime { get; set; }
        public int[] SeqLogin { get; set; }
        public string Dm { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string PosicaoPreferencial { get; set; }
        public string Inadimplente { get; set; }
        public string Filter { get; set; }
    }
}
