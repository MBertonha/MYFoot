using Modelo.Dominio.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Servico.Servicos
{
    public class ValidacaoGeTime
    {
        private readonly IGeTimeLeituraRepositorio _leiturarepositorio;
        public ValidacaoGeTime(IGeTimeLeituraRepositorio leiturarepositorio)
        {
            _leiturarepositorio = leiturarepositorio;
        }
        public bool ValidaTime(string nome)
        {
            var time =  _leiturarepositorio.BuscarPorNomeTime(nome);
            if(time != null)
            {
                return true;
            }
            return false;
        }
        public bool ValidaTipoPlano(int tipoplano)
        {
            if(tipoplano != 1 && tipoplano != 2)
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
