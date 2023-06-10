using HackCaixa.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Application.Helpers
{
    public static class Calculos
    {
        public static List<ParcelaDTO> CalcularSimulacaoSAC(decimal valorDesejado, int prazo, decimal taxaJuros)
        {
            var parcelas = new List<ParcelaDTO>();
            var amortizacao = valorDesejado / prazo;
            decimal saldoDevedor = valorDesejado;

            for (int i = 1; i <= prazo; i++)
            {
                var juros = saldoDevedor * taxaJuros;
                var prestacao = amortizacao + juros;

                var parcela = new ParcelaDTO
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

        public static List<ParcelaDTO> CalcularSimulacaoPrice(decimal valorDesejado, int prazo, decimal taxaJuros)
        {
           
            var parcelas = new List<ParcelaDTO>();
            var prestacao = (valorDesejado * taxaJuros) / (1- (decimal)Math.Pow((1+ (double)taxaJuros), -1*prazo));

            for (int i = 1; i <= prazo; i++)
            {
                var juros = valorDesejado * taxaJuros;
                var amortizacao = prestacao - juros;

                var parcela = new ParcelaDTO
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
