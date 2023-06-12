
using HackCaixa.Application.DTOs;
using HackCaixa.Application.Interfaces;
using HackCaixa.Application.Services;
using HackCaixa.Domain.Interfaces;
using HackCaixa.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackCaixaAPI.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtosService;
        private readonly IEventHubIntegration _eventHubIntegration;
        public ProdutosController(IProdutoService produtosService,
                                    IEventHubIntegration eventHubIntegration)
        {
            _produtosService = produtosService;
            _eventHubIntegration = eventHubIntegration;
        }


        [HttpPost]
        public async Task<IActionResult> Simulacao(EntradaSimulacaoDTO model)
        {
            try
            {
                if(!ModelState.IsValid) 
                {
                    var messages = ModelState
                        .SelectMany(ms => ms.Value.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    return BadRequest(messages);
                }
                var simulacao = await _produtosService.RealizarSimulacao(model.valorDesejado, model.prazo);
                if (simulacao == null) return BadRequest(new { message = "Não há produtos disponíveis para os parametros informados." });
                await _eventHubIntegration.SendMessageAsync(simulacao);
                return Ok(simulacao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar realizar Simulação. Erro: {ex.Message}");
            }
            
        }

      
    }
}
