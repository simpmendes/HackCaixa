using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Domain.Entities
{
    public class ResultadoSimulacao
    {
        public string Tipo { get; set; }
        public List<Parcela> Parcelas { get; set; }
        public ResultadoSimulacao(decimal valorDesejado, int prazo, string tipoSimulacao, decimal taxaJuros)
        {
                //Parcelas = new List<Parcela>();

                Tipo = tipoSimulacao;
                if (tipoSimulacao == "SAC")
                    Parcelas = CalcularSimulacaoSAC(valorDesejado, prazo, taxaJuros);
                else
                    Parcelas = CalcularSimulacaoPrice(valorDesejado, prazo, taxaJuros);
            
        }

        private List<Parcela> CalcularSimulacaoSAC(decimal valorDesejado, int prazo, decimal taxaJuros)
        {
            var parcelas = new List<Parcela>();
            var amortizacao = Math.Round(valorDesejado / prazo, 2);
            decimal saldoDevedor = valorDesejado;

            for (int i = 1; i <= prazo; i++)
            {
                var juros = Math.Round(saldoDevedor * taxaJuros, 2);
                var prestacao = Math.Round(amortizacao + juros, 2);

                var parcela = new Parcela
                {
                    Numero = i,
                    ValorAmortizacao = amortizacao,
                    ValorJuros = juros,
                    ValorPrestacao = prestacao
                };
                parcelas.Add(parcela);

                saldoDevedor -= amortizacao;
            }

            return parcelas;
        }

        private List<Parcela> CalcularSimulacaoPrice(decimal valorDesejado, int prazo, decimal taxaJuros)
        {

            var parcelas = new List<Parcela>();
            var prestacao = Math.Round((valorDesejado * taxaJuros) / (1 - (decimal)Math.Pow((1 + (double)taxaJuros), -1 * prazo)), 2);

            for (int i = 1; i <= prazo; i++)
            {
                var juros = Math.Round(valorDesejado * taxaJuros, 2);
                var amortizacao = Math.Round(prestacao - juros, 2);

                var parcela = new Parcela
                {
                    Numero = i,
                    ValorAmortizacao = amortizacao,
                    ValorJuros = juros,
                    ValorPrestacao = prestacao
                };
                parcelas.Add(parcela);

                valorDesejado -= amortizacao;
            }

            return parcelas;


        }


    }
}
