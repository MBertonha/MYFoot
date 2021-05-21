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

        public async Task<Ge_UsuarioDTO> BuscarPorNomeUsuario(string nomeusuario)
        {
            var brinde = await GetAll((e) => e.NomeUsuario == nomeusuario)
      .FirstOrDefaultAsync();
            return brinde.MapTo<Ge_UsuarioDTO>();
        }

        public async Task<Ge_UsuarioDTO> BuscarPorSeqUsuario(int sequsuario)
        {
            var brinde = await GetAll((e) => e.SeqUsuario == sequsuario)
      .FirstOrDefaultAsync();
            return brinde.MapTo<Ge_UsuarioDTO>();
        }

        public async Task<IListaBaseDto<Ge_UsuarioDTO>> BuscarTodos(BuscarTodosGe_UsuarioDTO buscarTodos)
        {
            var query = Table
                .OrderByDescending(x => x.SeqUsuario)
                .AsQueryable();

            //Se houver filtro na pesquisa
            if (!buscarTodos.Filter.IsNullOrEmpty())
            {
                query = query.Where(e =>
                    (EF.Functions.Like(e.SeqUsuario.ToString(), $"%{buscarTodos.SeqUsuario}%") ||
                    EF.Functions.Like(e.NomeUsuario.ToUpper(), $"%{buscarTodos.NomeUsuario}%") ||
                    EF.Functions.Like(e.DataNascimento.ToString(), $"%{buscarTodos.DataNascimento}%") ||
                    EF.Functions.Like(e.Endereco.ToUpper(), $"%{buscarTodos.Endereco}%") ||
                    EF.Functions.Like(e.CEP.ToUpper(), $"%{buscarTodos.CEP}%") ||
                    EF.Functions.Like(e.UF.ToUpper(), $"%{buscarTodos.UF}%") ||
                    EF.Functions.Like(e.Telefone.ToUpper(), $"%{buscarTodos.Telefone}%") ||
                    EF.Functions.Like(e.Email.ToUpper(), $"%{buscarTodos.Email}%") ||
                    EF.Functions.Like(e.Ativo.ToUpper(), $"%{buscarTodos.Ativo}%") ||
                    EF.Functions.Like(e.DataInclusao.ToString(), $"%{buscarTodos.DataInclusao}") ||
                    EF.Functions.Like(e.SeqTime.ToString(), $"%{buscarTodos.SeqTime}") ||
                    EF.Functions.Like(e.SeqLogin.ToString(), $"%{buscarTodos.SeqLogin}"))

                );
            }
            else
            {
                if (buscarTodos.SeqUsuario != null)
                {
                    query = query.Where(e => buscarTodos.SeqUsuario.Any((emp) => e.SeqUsuario == emp));
                }
                if (!buscarTodos.NomeUsuario.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.NomeUsuario.ToUpper(), $"%{buscarTodos.NomeUsuario.ToUpper()}%"));
                }
                if (buscarTodos.DataNascimento.ToString() != "01/01/0001 00:00:00")
                {
                    query = query.Where(e => EF.Functions.Like(e.DataNascimento.ToString(), $"%{buscarTodos.DataNascimento}%"));
                }
                if (!buscarTodos.Endereco.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Endereco.ToUpper(), $"%{buscarTodos.Endereco.ToUpper()}%"));
                }
                if (!buscarTodos.CEP.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.CEP.ToUpper(), $"%{buscarTodos.CEP.ToUpper()}%"));
                }
                if (!buscarTodos.UF.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.UF.ToUpper(), $"%{buscarTodos.UF.ToUpper()}%"));
                }
                if (!buscarTodos.Telefone.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Telefone.ToUpper(), $"%{buscarTodos.Telefone.ToUpper()}%"));
                }
                if (!buscarTodos.Email.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Email.ToUpper(), $"%{buscarTodos.Email.ToUpper()}%"));
                }
                if (!buscarTodos.Ativo.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Ativo.ToUpper(), $"%{buscarTodos.Ativo.ToUpper()}%"));
                }
                if (buscarTodos.DataInclusao.ToString() != "01/01/0001 00:00:00")
                {
                    query = query.Where(e => EF.Functions.Like(e.DataInclusao.ToString(), $"%{buscarTodos.DataInclusao}%"));
                }
            }

            return await query.RealizarConsultaAsync<GE_USUARIO, Ge_UsuarioDTO>(buscarTodos);
        }
    }
}


