﻿using AutoMapper;
using HackCaixa.Application.DTOs;
using HackCaixa.Application.Helpers;
using HackCaixa.Application.Interfaces;
using HackCaixa.Domain.Entities;
using HackCaixa.Infra.Data.Context;
using HackCaixa.Infra.Data.Interfaces;
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
            
            var produtosFiltrados =  _mapper.Map<IList<ProdutoDto>>(await _produtoRepository.FiltrarProdutosAsync(valorDesejado, prazo));

            // Realizar simulação para cada produto filtrado
            var resultadosSimulacao = new List<ResultadoSimulacaoDTO>();
            foreach (var produto in produtosFiltrados)
            {
                var resultadoSAC = Calculos.CalcularSimulacaoSAC(valorDesejado, prazo, produto.PcTaxaJuros);
                var resultadoPrice = Calculos.CalcularSimulacaoPrice(valorDesejado, prazo, produto.PcTaxaJuros);

                var resultadoSimulacao = new ResultadoSimulacaoDTO
                {
                    Tipo = "SAC",
                    Parcelas = resultadoSAC
                };
                resultadosSimulacao.Add(resultadoSimulacao);

                resultadoSimulacao = new ResultadoSimulacaoDTO
                {
                    Tipo = "Price",
                    Parcelas = resultadoPrice
                };
                resultadosSimulacao.Add(resultadoSimulacao);
            }

            var simulacao = new SimulacaoDTO
            {
                CodigoProduto = produtosFiltrados.FirstOrDefault()?.CoProduto ?? 0,
                DescricaoProduto = produtosFiltrados.FirstOrDefault()?.NoProduto,
                TaxaJuros = produtosFiltrados.FirstOrDefault()?.PcTaxaJuros ?? 0,
                ResultadoSimulacao = resultadosSimulacao
            };

            return simulacao;
        }

       


    }
}
