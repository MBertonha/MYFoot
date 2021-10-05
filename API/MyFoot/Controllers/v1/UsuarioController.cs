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
    public class UsuarioController : TnfController
    {
        private readonly IGeUsuarioLeituraRepositorio _leituraRepositorio;
        private readonly IGe_UsuarioServico _Servico;

        public UsuarioController(IGeUsuarioLeituraRepositorio leituraRepositorio,
            IGe_UsuarioServico servico)
        {
            _leituraRepositorio = leituraRepositorio;
            _Servico = servico;
        }

        //Traz todos os usuários
        [HttpGet]
        [ProducesResponseType(typeof(IListaBaseDto<Ge_UsuarioDTO>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarTodos([FromQuery] BuscarTodosGe_UsuarioDTO buscarTodos)
        {
            return CreateResponseOnGetAll(await _Servico.BuscarTodos(buscarTodos));
        }

        //Insere novo usuário
        [HttpPost]
        [ProducesResponseType(typeof(Ge_UsuarioDTO), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] AdicionarGe_UsuarioDTO exemploDto)
        {

            var exemplo = await _Servico.Adicionar(exemploDto);
            if (exemplo == null)
            {
                return BadRequest("Erro ao inserir Usuario");
            }
            else
            {
                return CreateResponseOnPost(exemplo);
            }
        }

        //Altera um Usuario
        [HttpPut]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(Ge_UsuarioDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Atualizar([FromQuery] int seqUsuario, [FromBody] Ge_UsuarioDTO exemploDto)
        {

            var exemplo = await _Servico.Atualizar(seqUsuario, exemploDto);
            if (exemplo == null)
            {
                return BadRequest("Erro ao alterar o Usuario");
            }
            else
            {
                return CreateResponseOnPut(exemplo);
            }
        }

    }
}
