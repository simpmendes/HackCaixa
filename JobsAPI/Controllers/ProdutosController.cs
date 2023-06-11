
using HackCaixa.Application.DTOs;
using HackCaixa.Application.Interfaces;
using HackCaixa.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackCaixaAPI.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtosService;
        public ProdutosController(IProdutoService produtosService)
        {
            _produtosService = produtosService;
        }

        // GET api/jobs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var produtos = await _produtosService.GetAllProdutosAsync();
                if (produtos == null) return NoContent();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar consultar produtos. Erro: {ex.Message}");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Simulacao(EntradaSimulacaoDTO model)
        {
            try
            {
                var simulacao = await _produtosService.RealizarSimulacao(model.valorDesejado, model.prazo);
                if (simulacao == null) return BadRequest(new { message = "Não há produtos disponíveis para os parametros informados." });
                return Ok(simulacao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar realizar Simulação. Erro: {ex.Message}");
            }
            
        }

      
    }
}
