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
            // GE Login
            #region Domínio para Dto
            CreateMap<GE_LOGIN, Ge_LoginDTO>();
            CreateMap<GE_LOGIN, AdicionarGE_LoginDTO>();
            CreateMap<GE_LOGIN, BuscarTodosGe_LoginDTO>();
            CreateMap<GE_LOGIN, AlterarGe_LoginDTO>();
            #endregion

            #region DTO para Domínio
            CreateMap<Ge_LoginDTO, GE_LOGIN>();
            CreateMap<BuscarTodosGe_LoginDTO, GE_LOGIN>();
            CreateMap<AdicionarGE_LoginDTO, GE_LOGIN>();
            CreateMap<AlterarGe_LoginDTO, GE_LOGIN>();
            #endregion
            // GE Time
            #region Domínio para Dto
            CreateMap<GE_TIME, Ge_TimeDTO>();
            CreateMap<GE_TIME, AdicionarGE_TimeDTO>();
            CreateMap<GE_TIME, BuscarTodosGe_TimeDTO>();
            CreateMap<GE_TIME, AlterarGe_TimeDTO>();
            #endregion

            #region DTO para Domínio
            CreateMap<Ge_TimeDTO, GE_TIME>();
            CreateMap<BuscarTodosGe_TimeDTO, GE_TIME>();
            CreateMap<AdicionarGE_TimeDTO, GE_TIME>();
            CreateMap<AlterarGe_TimeDTO, GE_TIME>();
            #endregion

            #region DTO para DTO
            CreateMap<Ge_TimeDTO, BuscarTodosGe_TimeDTO>();
            CreateMap<BuscarTodosGe_TimeDTO, Ge_TimeDTO>();
            #endregion
            //GE Usuario
            #region Domínio para Dto
            CreateMap<GE_USUARIO, Ge_UsuarioDTO>();
            CreateMap<GE_USUARIO, AdicionarGE_UsuarioDTO>();
            CreateMap<GE_USUARIO, BuscarTodosGe_UsuarioDTO>();
            CreateMap<GE_USUARIO, AlterarGe_UsuarioDTO>();
            #endregion

            #region DTO para Domínio
            CreateMap<Ge_UsuarioDTO, GE_USUARIO>();
            CreateMap<BuscarTodosGe_UsuarioDTO, GE_USUARIO>();
            CreateMap<AdicionarGE_UsuarioDTO, GE_USUARIO>();
            CreateMap<AlterarGe_UsuarioDTO, GE_USUARIO>();
            #endregion

            #region DTO para DTO
            CreateMap<Ge_UsuarioDTO, BuscarTodosGe_UsuarioDTO>();
            CreateMap<BuscarTodosGe_UsuarioDTO, Ge_UsuarioDTO>();
            #endregion
        }
    }
}
