using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Application.DTOs
{
    public class SimulacaoDTO
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal TaxaJuros { get; set; }
        public List<ResultadoSimulacaoDTO> ResultadoSimulacao { get; set; }
    }
}
