using Microsoft.EntityFrameworkCore;
using Modelo.Dominio.DTO;
using Modelo.Dominio.DTO.Interfaces;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Modelos.Dtos;
using Modelo.Infra.Contexto;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tnf.Dto;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace Modelo.Infra.Repositorios
{
    public class Ge_LoginLeituraRepositorio : EfCoreRepositoryBase<MyFootContexto, GE_LOGIN>, IGeLoginLeituraRepositorio
    {
        public Ge_LoginLeituraRepositorio(IDbContextProvider<MyFootContexto> dbContextProvider) : base(dbContextProvider)
        {
        }
        public async Task<Ge_LoginDTO> BuscarPorId(int seqLogin)
        {
            var brinde = await GetAll((e) => e.SeqLogin == seqLogin)
                .FirstOrDefaultAsync();
            return brinde.MapTo<Ge_LoginDTO>();
        }

        public async Task<IListaBaseDto<Ge_LoginDTO>> BuscarTodos(BuscarTodosGe_LoginDTO model)
        {
            var query = Table
                .OrderByDescending(x => x.SeqLogin)
                .AsQueryable();

            //Se houver filtro na pesquisa
            if (!model.Filter.IsNullOrEmpty())
            {
                query = query.Where(e =>
                    (EF.Functions.Like(e.SeqLogin.ToString(), $"%{model.SeqLogin}%") ||
                    EF.Functions.Like(e.Ativo.ToUpper(), $"%{model.Ativo}%") ||
                    EF.Functions.Like(e.EmailLogin.ToUpper(), $"%{model.EmailLogin}%") ||
                    EF.Functions.Like(e.TipoUsuario.ToString(), $"%{model.TipoUsuario}"))
                );
            }
            else
            {
                if(model.SeqLogin != null)
                {
                    query = query.Where(e => model.SeqLogin.Any((emp) => e.SeqLogin == emp));
                }
                if(!model.EmailLogin.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.EmailLogin.ToUpper(), $"%{model.EmailLogin.ToUpper()}%"));
                }
                if(model.TipoUsuario != null)
                {
                    query = query.Where(e => model.TipoUsuario.Any((emp) => e.TipoUsuario == emp));
                }
                if (!model.Ativo.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Ativo.ToUpper(), $"%{model.Ativo.ToUpper()}%"));
                }
            }

            return await query.RealizarConsultaAsync<GE_LOGIN, Ge_LoginDTO>(model);
        }
    }
}
