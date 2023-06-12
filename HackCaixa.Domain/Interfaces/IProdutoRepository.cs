using HackCaixa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> FiltrarProdutosAsync(decimal valorDesejado, int prazo);
    }
}
