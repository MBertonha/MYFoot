using Modelo.Dominio.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Modelo.Servico.Servicos
{
    public class ValidacaoGeUsuario
    {
        private readonly IGeUsuarioLeituraRepositorio _leiturarepositorio;
        public ValidacaoGeUsuario(IGeUsuarioLeituraRepositorio leiturarepositorio)
        {
            _leiturarepositorio = leiturarepositorio;
        }
        public bool ValidaUsuario(string nome)
        {
            var usuario = _leiturarepositorio.BuscarPorNomeUsuario(nome);
            if (usuario != null)
            {
                return true;
            }
            return false;
        }
        public bool ValidaEmail(string email)
        {
            if (email.Length > 30)
            {
                return true;
            }

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!rg.IsMatch(email))
            {
                return true;
            }

            return false;
        }
        public bool ValidaAtivo(string ativo)
        {
            if (ativo != "S" && ativo != "N")
            {
                return true;
            }
            return false;
        }
    }
}
