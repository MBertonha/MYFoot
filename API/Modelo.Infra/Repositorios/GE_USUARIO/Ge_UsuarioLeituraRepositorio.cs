using Microsoft.EntityFrameworkCore;
using Modelo.Dominio.DTO;
using Modelo.Dominio.DTO.Interfaces;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Modelos.Dtos;
using Modelo.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace Modelo.Infra.Repositorios
{
    public class Ge_UsuarioLeituraRepositorio : EfCoreRepositoryBase<MyFootContexto, GE_USUARIO>, IGeUsuarioLeituraRepositorio
    {
        public Ge_UsuarioLeituraRepositorio(IDbContextProvider<MyFootContexto> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Ge_UsuarioDTO> BuscarPorNome(string nomeUsuario)
        {
            var retorno = await GetAll((e) => e.NomeUsuario == nomeUsuario).FirstOrDefaultAsync();
            return retorno.MapTo<Ge_UsuarioDTO>();
        }

        public async Task<Ge_UsuarioDTO> BuscarPorSeqLogin(int seqLogin)
        {
            var retorno = await GetAll((e) => e.SeqLogin == seqLogin).FirstOrDefaultAsync();
            return retorno.MapTo<Ge_UsuarioDTO>();
        }

        public async Task<Ge_UsuarioDTO> BuscarPorSeqTime(int seqtime)
        {
            var retorno = await GetAll((e) => e.SeqTime == seqtime).FirstOrDefaultAsync();
            return retorno.MapTo<Ge_UsuarioDTO>();
        }

        public async Task<IListaBaseDto<Ge_UsuarioDTO>> BuscarTodos(BuscarTodosGe_UsuarioDTO buscarTodos)
        {
            var query = Table
                .OrderByDescending(x => x.SeqUsuario)
                .AsQueryable();

            var teste = query.ToList();

            //Se houver filtro na pesquisa
            if (!buscarTodos.Filter.IsNullOrEmpty())
            {
                query = query.Where(e =>
                    (EF.Functions.Like(e.SeqUsuario.ToString(), $"%{buscarTodos.SeqUsuario}%") ||
                    EF.Functions.Like(e.Ativo.ToUpper(), $"%{buscarTodos.Ativo.ToUpper()}%") ||
                    EF.Functions.Like(e.NomeUsuario.ToUpper(), $"%{buscarTodos.NomeUsuario.ToUpper()}%") ||
                    EF.Functions.Like(e.Cep.ToUpper(), $"%{buscarTodos.Cep.ToUpper()}%") ||
                    EF.Functions.Like(e.Uf.ToUpper(), $"%{buscarTodos.Uf.ToUpper()}%") ||
                    EF.Functions.Like(e.Email.ToUpper(), $"%{buscarTodos.Email.ToUpper()}")) ||
                    EF.Functions.Like(e.Telefone.ToUpper(), $"%{buscarTodos.Telefone}") ||
                    EF.Functions.Like(e.SeqLogin.ToString(), $"%{buscarTodos.SeqLogin}") ||
                    EF.Functions.Like(e.SeqTime.ToString(), $"%{buscarTodos.SeqTime}") ||
                    EF.Functions.Like(e.Dm.ToUpper(), $"%{buscarTodos.Dm.ToUpper()}") ||
                    EF.Functions.Like(e.DtaInclusao.ToString(), $"%{buscarTodos.DtaInclusao}") ||
                    EF.Functions.Like(e.DtaNascimento.ToString(), $"%{buscarTodos.DtaNascimento}")||
                    EF.Functions.Like(e.Cpf, $"%{buscarTodos.Cpf}") ||
                    EF.Functions.Like(e.Rg, $"%{buscarTodos.Rg}") ||
                    EF.Functions.Like(e.Inadimplente.ToUpper(), $"%{buscarTodos.Inadimplente.ToUpper()}") ||
                    EF.Functions.Like(e.PosicaoPreferencial.ToUpper(), $"%{buscarTodos.PosicaoPreferencial.ToUpper()}") ||
                    EF.Functions.Like(e.Endereco.ToUpper(), $"%{buscarTodos.Endereco.ToUpper()}")
                );
            }
            else
            {
                if (buscarTodos.SeqTime != null)
                {
                    query = query.Where(e => buscarTodos.SeqTime.Any((emp) => e.SeqTime == emp));
                }
                if (buscarTodos.SeqUsuario != null)
                {
                    query = query.Where(e => buscarTodos.SeqUsuario.Any((emp) => e.SeqUsuario == emp));
                }
                if (buscarTodos.SeqLogin != null)
                {
                    query = query.Where(e => buscarTodos.SeqLogin.Any((emp) => e.SeqLogin == emp));
                }
                if (!buscarTodos.NomeUsuario.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.NomeUsuario.ToUpper(), $"%{buscarTodos.NomeUsuario.ToUpper()}%"));
                }
                if (!buscarTodos.Cep.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Cep.ToUpper(), $"%{buscarTodos.Cep.ToUpper()}%"));
                }
                if (!buscarTodos.Ativo.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Ativo.ToUpper(), $"%{buscarTodos.Ativo.ToUpper()}%"));
                }
                if (!buscarTodos.Uf.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Uf.ToUpper(), $"%{buscarTodos.Uf.ToUpper()}%"));
                }
                if (!buscarTodos.Email.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Email.ToUpper(), $"%{buscarTodos.Email.ToUpper()}%"));
                }
                if (!buscarTodos.Telefone.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Telefone.ToUpper(), $"%{buscarTodos.Telefone.ToUpper()}%"));
                }
                if (!buscarTodos.Dm.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Dm.ToUpper(), $"%{buscarTodos.Dm.ToUpper()}%"));
                }
                if (buscarTodos.DtaNascimento.ToString() != "01/01/0001 00:00:00")
                {
                    query = query.Where(e => EF.Functions.Like(e.DtaNascimento.ToString(), $"%{buscarTodos.DtaNascimento.ToString()}%"));
                }
                if (buscarTodos.DtaInclusao.ToString() != "01/01/0001 00:00:00")
                {
                    query = query.Where(e => EF.Functions.Like(e.DtaInclusao.ToString(), $"%{buscarTodos.DtaInclusao.ToString()}%"));
                }
                if (!buscarTodos.Endereco.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Endereco.ToUpper(), $"%{buscarTodos.Endereco.ToUpper()}%"));
                }
                if (!buscarTodos.Rg.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Rg.ToUpper(), $"%{buscarTodos.Rg.ToUpper()}%"));
                }
                if (!buscarTodos.Cpf.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Cpf.ToUpper(), $"%{buscarTodos.Cpf.ToUpper()}%"));
                }
                if (!buscarTodos.Inadimplente.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Inadimplente.ToUpper(), $"%{buscarTodos.Inadimplente.ToUpper()}%"));
                }
                if (!buscarTodos.PosicaoPreferencial.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.PosicaoPreferencial.ToUpper(), $"%{buscarTodos.PosicaoPreferencial.ToUpper()}%"));
                }
            }

            return await query.RealizarConsultaAsync<GE_USUARIO, Ge_UsuarioDTO>(buscarTodos);
        }
    }
}
