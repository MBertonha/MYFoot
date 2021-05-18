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

namespace MyFoot.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class LoginController : TnfController
    {
        private readonly IGeLoginLeituraRepositorio _leituraRepositorio;
        private readonly IGe_LoginServico _Servico;

        public LoginController(IGeLoginLeituraRepositorio leituraRepositorio,
            IGe_LoginServico servico)
        {
            _leituraRepositorio = leituraRepositorio;
            _Servico = servico;
        }

        //Traz todos os usuários
        [HttpGet]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(IListaBaseDto<Ge_LoginDTO>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarTodos([FromQuery] BuscarTodosGe_LoginDTO buscarTodos)
        {
            return CreateResponseOnGetAll(await _Servico.BuscarTodos(buscarTodos));
        }

        //Retorna um unico usuário pelo email e senha
        [HttpGet("usuario")]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(BuscarUmGe_LoginDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarUsuario(string email, string senha)
        {
            var retorno = await _Servico.BuscarUmUsuario(email, senha);

            return CreateResponseOnGet(retorno);
        }

        //Insere novo usuário
        [HttpPost]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(Ge_LoginDTO), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] AdicionarGE_LoginDTO exemploDto)
        {

            var exemplo = await _Servico.Adicionar(exemploDto);

            return CreateResponseOnPost(exemplo);
        }

        //Altera uum usuário 
        [HttpPut]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(Ge_LoginDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Atualizar(string email, string senha, [FromBody] Ge_LoginDTO exemploDto)
        {

            var exemplo = await _Servico.Atualizar(email, senha, exemploDto);

            return CreateResponseOnPut(exemplo);
        }

    }
}
