using HackCaixa.Domain.Entities;
using HackCaixa.Infra.Data.Context;
using HackCaixa.Infra.Data.Interfaces;
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
