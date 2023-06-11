using AutoMapper;
using HackCaixa.Application.DTOs;
using HackCaixa.Application.Helpers;
using HackCaixa.Application.Interfaces;
using HackCaixa.Domain.Entities;
using HackCaixa.Domain.Interfaces;
using HackCaixa.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Application.Services
{
    public class ProdutoService :  IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<IList<ProdutoDto>> GetAllProdutosAsync()
        {
            var produtos = await _produtoRepository.GetAllProdutosAsync();
            return _mapper.Map<IList<ProdutoDto>>(produtos);
        }
        
        public async Task<SimulacaoDTO> RealizarSimulacao(decimal valorDesejado, int prazo)
        {
            
            var produtoFiltrado =  await _produtoRepository.FiltrarProdutosAsync(valorDesejado, prazo);

            if (produtoFiltrado != null)
            {
                // Realizar simulação 
                var resultadosSimulacao = new List<ResultadoSimulacaoDTO>();

                var simulacao = new Simulacao(produtoFiltrado, valorDesejado, prazo);

                return _mapper.Map<SimulacaoDTO>(simulacao);
            }
            else
                return null;
            
        }

    }
}

