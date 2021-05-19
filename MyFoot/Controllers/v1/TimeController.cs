using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Dominio.DTO;
using Modelo.Dominio.DTO.Interfaces;
using Modelo.Dominio.Modelos.Dtos;
using Modelo.Servico.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tnf.AspNetCore.Mvc.Response;

namespace Modelo.Aplicacao.Controllers.v1
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class TimeController : TnfController
    {
        private readonly IGeTimeLeituraRepositorio _leituraRepositorio;
        private readonly IGe_TimeServico _Servico;

        public TimeController(IGeTimeLeituraRepositorio leituraRepositorio,
            IGe_TimeServico servico)
        {
            _leituraRepositorio = leituraRepositorio;
            _Servico = servico;
        }

        //Traz todos os usuários
        [HttpGet]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(IListaBaseDto<Ge_TimeDTO>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarTodos([FromQuery] BuscarTodosGe_TimeDTO buscarTodos)
        {
            return CreateResponseOnGetAll(await _Servico.BuscarTodos(buscarTodos));
        }

        //Retorna um unico usuário pelo email e senha
        [HttpGet("time")]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(Ge_TimeDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarTime(string nometime)
        {
            var retorno = await _Servico.BuscarUmTime(nometime);
            if (retorno == null)
            {
                return BadRequest("Erro ao buscar time");
            }
            else
            {
                return CreateResponseOnGet(retorno);
            }
        }

        //Insere novo usuário
        [HttpPost]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(Ge_TimeDTO), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] AdicionarGE_TimeDTO exemploDto)
        {

            var exemplo = await _Servico.Adicionar(exemploDto);
            if (exemplo == null)
            {
                return BadRequest("Erro ao inserir time");
            }
            else
            {
                return CreateResponseOnPost(exemplo);
            }
        }

        //Altera um usuário 
        //[HttpPut]
        //[Authorize("Bearer")]
        //[ProducesResponseType(typeof(Ge_TimeDTO), 200)]
        //[ProducesResponseType(typeof(ErrorResponse), 400)]
        //public async Task<IActionResult> Atualizar(string email, string senha, [FromBody] Ge_TimeDTO exemploDto)
        //{

        //    var exemplo = await _Servico.Atualizar(email, senha, exemploDto);
        //    if (exemplo == null)
        //    {
        //        return BadRequest("Erro ao atualizar login");
        //    }
        //    else
        //    {
        //        return CreateResponseOnPut(exemplo);
        //    }
        //}

    }
}
