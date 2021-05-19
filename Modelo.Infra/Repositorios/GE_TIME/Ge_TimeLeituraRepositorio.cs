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
    public class Ge_TimeLeituraRepositorio : EfCoreRepositoryBase<MyFootContexto, GE_TIME>, IGeTimeLeituraRepositorio
    {
        public Ge_TimeLeituraRepositorio(IDbContextProvider<MyFootContexto> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Ge_TimeDTO> BuscarPorNomeTime(string nometime)
        {
            var brinde = await GetAll((e) => e.NomeTime == nometime)
      .FirstOrDefaultAsync();
            return brinde.MapTo<Ge_TimeDTO>();
        }

        public async Task<Ge_TimeDTO> BuscarPorSeqTime(int seqtime)
        {
            var brinde = await GetAll((e) => e.SeqTime == seqtime)
      .FirstOrDefaultAsync();
            return brinde.MapTo<Ge_TimeDTO>();
        }

        public async Task<IListaBaseDto<Ge_TimeDTO>> BuscarTodos(BuscarTodosGe_TimeDTO buscarTodos)
        {
            var query = Table
                .OrderByDescending(x => x.SeqTime)
                .AsQueryable();

            //Se houver filtro na pesquisa
            if (!buscarTodos.Filter.IsNullOrEmpty())
            {
                query = query.Where(e =>
                    (EF.Functions.Like(e.SeqTime.ToString(), $"%{buscarTodos.SeqTime}%") ||
                    EF.Functions.Like(e.Ativo.ToUpper(), $"%{buscarTodos.Ativo}%") ||
                    EF.Functions.Like(e.NomeTime.ToUpper(), $"%{buscarTodos.NomeTime}%") ||
                    EF.Functions.Like(e.CEP.ToUpper(), $"%{buscarTodos.CEP}%") ||
                    EF.Functions.Like(e.UF.ToUpper(), $"%{buscarTodos.UF}%") ||
                    EF.Functions.Like(e.TipoPlano.ToString(), $"%{buscarTodos.TipoPlano}")) ||
                    EF.Functions.Like(e.DataInclusao.ToString(), $"%{buscarTodos.DataInclusao}")
                );
            }
            else
            {
                if (buscarTodos.SeqTime != null)
                {
                    query = query.Where(e => buscarTodos.SeqTime.Any((emp) => e.SeqTime == emp));
                }
                if (!buscarTodos.NomeTime.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.NomeTime.ToUpper(), $"%{buscarTodos.NomeTime.ToUpper()}%"));
                }
                if (buscarTodos.TipoPlano != null)
                {
                    query = query.Where(e => buscarTodos.TipoPlano.Any((emp) => e.TipoPlano== emp));
                }
                if (!buscarTodos.Ativo.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Ativo.ToUpper(), $"%{buscarTodos.Ativo.ToUpper()}%"));
                }
                if (!buscarTodos.CEP.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.CEP.ToUpper(), $"%{buscarTodos.CEP.ToUpper()}%"));
                }
                if (!buscarTodos.UF.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.UF.ToUpper(), $"%{buscarTodos.UF.ToUpper()}%"));
                }
            }

            return await query.RealizarConsultaAsync<GE_TIME, Ge_TimeDTO>(buscarTodos);
        }
    }
}
