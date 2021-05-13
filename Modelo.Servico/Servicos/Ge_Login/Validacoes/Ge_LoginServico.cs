﻿using Modelo.Dominio.DTO;
using Modelo.Dominio.DTO.Interfaces;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Modelos.Dtos;
using Modelo.Servico.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Notifications;
using Tnf.Repositories.Uow;

namespace Modelo.Servico.Servicos
{
    public class Ge_LoginServico : ServicoBase<GE_LOGIN>, IGe_LoginServico
    {
        private readonly INotificationHandler _controleNotificacao;
        private readonly IUnitOfWorkManager _controleTransacao;
        private readonly IGeLoginRepositorio _Repositorio;
        private readonly IGeLoginLeituraRepositorio _LeituraRepositorio;

        public Ge_LoginServico(
           INotificationHandler controleNotificacao,
           IUnitOfWorkManager controleTransacao,
           IGeLoginRepositorio repositorio,
           IGeLoginLeituraRepositorio leituraRepositorio
       ) : base(controleNotificacao, controleTransacao)
        {
            _controleTransacao = controleTransacao;
            _controleNotificacao = controleNotificacao;
            _Repositorio = repositorio;
            _LeituraRepositorio = leituraRepositorio;
        }

        public Task<AdicionarGE_LoginDTO> Adicionar(AdicionarGE_LoginDTO exemplo)
        {
            throw new NotImplementedException();
        }

        public Task<AlterarGe_LoginDTO> Atualizar(int id, Ge_LoginDTO exemploAtualizado)
        {
            throw new NotImplementedException();
        }

        public Task<Ge_LoginDTO> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IListaBaseDto<Ge_LoginDTO>> BuscarTodos(BuscarTodosGe_LoginDTO buscarTodos)
        {
            return await _LeituraRepositorio.BuscarTodos(buscarTodos);
        }

        protected override Task<bool> VerificaInconsistencias(GE_LOGIN obj)
        {
            throw new NotImplementedException();
        }
    }
}