﻿using Modelo.Dominio.Modelos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Repositories;

namespace Modelo.Dominio.DTO.Interfaces
{
    public interface IGeUsuarioLeituraRepositorio : IRepository
    {
        Task<IListaBaseDto<Ge_UsuarioDTO>> BuscarTodos(BuscarTodosGe_UsuarioDTO buscarTodos);
        Task<Ge_UsuarioDTO> BuscarPorNome(string nometime);
        Task<Ge_UsuarioDTO> BuscarPorSeqTime(int seqtime);
        Task<Ge_UsuarioDTO> BuscarPorSeqLogin(int seqtime);
    }
}