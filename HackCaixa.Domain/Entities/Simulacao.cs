using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Domain.Entities
{
    public class Simulacao
    {
        public Produto Produto { get; set; }
        public List<ResultadoSimulacao> ResultadoSimulacao { get; set; }

        public Simulacao(Produto produto, decimal valorDesejado, int prazo)
        {
            Produto = produto;
            var resultadoSimulacao = new List<ResultadoSimulacao>
            {
                new ResultadoSimulacao(valorDesejado, prazo, "SAC", produto.PcTaxaJuros),
                new ResultadoSimulacao(valorDesejado, prazo, "PRICE", produto.PcTaxaJuros)
            };
            ResultadoSimulacao =resultadoSimulacao;
        }

    }
}
