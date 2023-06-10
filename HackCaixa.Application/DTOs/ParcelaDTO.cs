using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Application.DTOs
{
    public class ParcelaDTO
    {
        public int Numero { get; set; }
        public decimal ValorAmortizacao { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorPrestacao { get; set; }
    }
}
