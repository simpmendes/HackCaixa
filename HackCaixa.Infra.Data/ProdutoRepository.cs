using HackCaixa.Domain.Entities;
using HackCaixa.Infra.Data.Context;
using HackCaixa.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Infra.Data
{
    public class ProdutoRepository: RepositoryBase, IProdutoRepository
    {
        private readonly ProdutosDBContext _context;
        public ProdutoRepository(ProdutosDBContext context) : base(context)
        {
            _context = context;

        }

        public async Task<IList<Produto>> GetAllProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<IList<Produto>> FiltrarProdutosAsync(decimal valorDesejado, int prazo)
        {
            return await _context.Produtos.Where(p => valorDesejado >= p.VrMinimo &&
                                                (p.VrMaximo == null || valorDesejado <= p.VrMaximo) &&
                                                 prazo >= p.NuMinimoMeses && (p.NuMaximoMeses == null || prazo <= p.NuMaximoMeses)).ToListAsync();
            
        }

       
    }
}
