
using Js.ApiGateways.Services;
using JS.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Js.ApiGateways.Controllers
{
    [Authorize]
    [Route("api/contas")]
    public class ContasController : MainController
    {        
        private readonly IContaService _contaService;

        public ContasController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet("lista-contas")]
        public async Task<IActionResult> ListaContas()
        {
            return CustomResponse(await _contaService.ObterListaContas());
        }

        [HttpGet("por-tipo/{tipo:int}")]
        public async Task<IActionResult> ListaContasPorTipo(int tipo)
        {
            return CustomResponse(await _contaService.ObterListaContasPorTipo(tipo));
        }

        [HttpGet("por-idConta/{id:guid}")]
        public async Task<IActionResult> ObterContasPorId(Guid id)
        {
            return CustomResponse(await _contaService.ObterContaPorId(id));
        }

        [HttpGet("por-status/{tipo:int}")]
        public async Task<IActionResult> ListaContasPorStatus(int tipo, int status)
        {
            return CustomResponse(await _contaService.ObterListaContasPorStatus(tipo, status));
        }
    }
}
