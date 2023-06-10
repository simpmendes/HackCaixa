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
        }
    }
}
