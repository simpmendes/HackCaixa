using AutoMapper;
using HackCaixa.Application.DTOs;
using HackCaixa.Domain.Entities;

namespace HackCaixa.Application.Helpers
{
    public class ProdutosProfile : Profile
    {
        public ProdutosProfile() 
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<Parcela, ParcelaDTO>().ReverseMap();
            CreateMap<ResultadoSimulacao, ResultadoSimulacaoDTO>()
            .ForMember(dest => dest.Parcelas, opt => opt.MapFrom(src => src.Parcelas));

            CreateMap<Simulacao, SimulacaoDTO>()
                .ForMember(dest => dest.CodigoProduto, opt => opt.MapFrom(src => src.Produto.CoProduto))
                .ForMember(dest => dest.DescricaoProduto, opt => opt.MapFrom(src => src.Produto.NoProduto))
                .ForMember(dest => dest.TaxaJuros, opt => opt.MapFrom(src => src.Produto.PcTaxaJuros));
        }
    }
}
