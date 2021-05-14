using AutoMapper;
using Modelo.Dominio.DTO;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Servico.AutoMapper
{
    public class MyFootProfile : Profile
    {
        public MyFootProfile()
        {
            #region Domínio para Dto
            CreateMap<GE_LOGIN, Ge_LoginDTO>();
            CreateMap<GE_LOGIN, AdicionarGE_LoginDTO>();
            CreateMap<GE_LOGIN, BuscarTodosGe_LoginDTO>();
            CreateMap<GE_LOGIN, AlterarGe_LoginDTO>();
            #endregion

            #region Dto para Domínio
            CreateMap<Ge_LoginDTO, GE_LOGIN>();
            CreateMap<BuscarTodosGe_LoginDTO, GE_LOGIN>();
            CreateMap<AdicionarGE_LoginDTO, GE_LOGIN>();
            CreateMap<AlterarGe_LoginDTO, GE_LOGIN>();
            #endregion

        }
    }
}
