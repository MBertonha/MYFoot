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
    public class JogadorController : TnfController
    {
        private readonly IGeJogadorLeituraRepositorio _leituraRepositorio;
        private readonly IGe_JogadorServico _Servico;

        public JogadorController(IGeJogadorLeituraRepositorio leituraRepositorio,
            IGe_JogadorServico servico)
        {
            _leituraRepositorio = leituraRepositorio;
            _Servico = servico;
        }

        //Traz todos os usuários
        [HttpGet]
        [ProducesResponseType(typeof(IListaBaseDto<Ge_JogadorDTO>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarTodos([FromQuery] BuscarTodosGe_JogadorDTO buscarTodos)
        {
            return CreateResponseOnGetAll(await _Servico.BuscarTodos(buscarTodos));
        }

        //Insere novo usuário
        [HttpPost]
        [ProducesResponseType(typeof(Ge_JogadorDTO), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] AdicionarGe_JogadorDto exemploDto)
        {

            var exemplo = await _Servico.Adicionar(exemploDto);
            if (exemplo == null)
            {
                return BadRequest("Erro ao inserir Jogador");
            }
            else
            {
                return CreateResponseOnPost(exemplo);
            }
        }

        ////Altera um Jogador
        //[HttpPut]
        ////[Authorize("Bearer")]
        //[ProducesResponseType(typeof(Ge_JogadorDTO), 200)]
        //[ProducesResponseType(typeof(ErrorResponse), 400)]
        //public async Task<IActionResult> Atualizar([FromQuery] int seqJogador, [FromBody] Ge_JogadorDTO exemploDto)
        //{

        //    var exemplo = await _Servico.Atualizar(seqJogador, exemploDto);
        //    if (exemplo == null)
        //    {
        //        return BadRequest("Erro ao alterar o Jogador");
        //    }
        //    else
        //    {
        //        return CreateResponseOnPut(exemplo);
        //    }
        //}
    }
    }
