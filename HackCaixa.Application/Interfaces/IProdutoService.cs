using HackCaixa.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IList<ProdutoDto>> GetAllProdutosAsync();
        Task<SimulacaoDTO> RealizarSimulacao(decimal valorDesejado, int prazo);
    }
}
