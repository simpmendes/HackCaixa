using FluentValidation;
using HackCaixa.Application.DTOs;

namespace HackCaixa.Application.Validators
{
    public class EntradaSimulacaoDTOValidator: AbstractValidator<EntradaSimulacaoDTO>
    {
        public EntradaSimulacaoDTOValidator()
        {
            RuleFor(p => p.valorDesejado)
                    .GreaterThan(0)
                    .Must(valor => decimal.TryParse(valor.ToString(), out _))
                    .WithMessage("O Valor desejado deve ser maior que zero e um número válido.");


            RuleFor(p => p.prazo)
           .Must(valor => int.TryParse(valor.ToString(), out _))
           .WithMessage("O valor do prazo deve ser um número inteiro.");
        }

      
}
