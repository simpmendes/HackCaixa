using HackCaixa.Domain.Entities;
using HackCaixa.Domain.Interfaces;
using HackCaixa.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Infra.Data
{
    public class RepositoryBase: IRepositoryBase
    {
        private readonly ProdutosDBContext _context;
        public RepositoryBase(ProdutosDBContext context)
        {
            _context = context;
        }
       
    }
}
