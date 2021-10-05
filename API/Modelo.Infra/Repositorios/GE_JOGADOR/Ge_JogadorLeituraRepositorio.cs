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
    public class Ge_JogadorLeituraRepositorio : EfCoreRepositoryBase<MyFootContexto, GE_JOGADOR>, IGeJogadorLeituraRepositorio
    {
        public Ge_JogadorLeituraRepositorio(IDbContextProvider<MyFootContexto> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<IListaBaseDto<Ge_JogadorDTO>> BuscarTodos(BuscarTodosGe_JogadorDTO model)
        {
            var query = Table
                .OrderByDescending(x => x.SeqJogador)
                .AsQueryable();

            //Se houver filtro na pesquisa
            if (!model.Filter.IsNullOrEmpty())
            {
                query = query.Where(e =>
                    (EF.Functions.Like(e.SeqJogador.ToString(), $"%{model.SeqJogador}%") ||
                    EF.Functions.Like(e.SeqUsuario.ToString(), $"%{model.SeqUsuario}%") ||
                    EF.Functions.Like(e.Status.ToUpper(), $"%{model.Status.ToUpper()}%") ||
                    EF.Functions.Like(e.Ca.ToString(), $"%{model.Ca}%") ||
                    EF.Functions.Like(e.Cv.ToString(), $"%{model.Cv}%") ||
                    EF.Functions.Like(e.GolsSofridos.ToString(), $"%{model.GolsSofridos}%") ||
                    EF.Functions.Like(e.JogosJogados.ToString(), $"%{model.JogosJogados}%") ||
                    EF.Functions.Like(e.Gols.ToString(), $"%{model.Gols}"))
                );
            }
            else
            {
                if (model.SeqJogador != null)
                {
                    query = query.Where(e => model.SeqJogador.Any((emp) => e.SeqJogador == emp));
                }
                if (model.SeqUsuario != null)
                {
                    query = query.Where(e => model.SeqUsuario.Any((emp) => e.SeqUsuario == emp));
                }
                if (model.Ca != null)
                {
                    query = query.Where(e => model.Ca.Any((emp) => e.Ca == emp));
                }
                if (model.Cv != null)
                {
                    query = query.Where(e => model.Cv.Any((emp) => e.Cv == emp));
                }
                if (model.Gols != null)
                {
                    query = query.Where(e => model.Gols.Any((emp) => e.Gols == emp));
                }
                if (model.GolsSofridos != null)
                {
                    query = query.Where(e => model.GolsSofridos.Any((emp) => e.GolsSofridos == emp));
                }
                if (model.JogosJogados != null)
                {
                    query = query.Where(e => model.JogosJogados.Any((emp) => e.JogosJogados == emp));
                }
                if (!model.Status.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Status.ToUpper(), $"%{model.Status.ToUpper()}%"));
                }
            }

            return await query.RealizarConsultaAsync<GE_JOGADOR, Ge_JogadorDTO>(model);
        }
    }
}
