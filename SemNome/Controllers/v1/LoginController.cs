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

namespace SemNome.Controllers.v1
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

        [HttpGet]
        //[Authorize("Bearer")]
        [ProducesResponseType(typeof(IListaBaseDto<Ge_LoginDTO>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarTodos([FromQuery] BuscarTodosGe_LoginDTO buscarTodos)
        {
            return CreateResponseOnGetAll(await _Servico.BuscarTodos(buscarTodos));
        }

    }
}
