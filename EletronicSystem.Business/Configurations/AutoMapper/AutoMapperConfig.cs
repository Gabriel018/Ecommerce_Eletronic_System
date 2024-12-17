using AutoMapper;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Domain.Entities;

namespace EletronicSystem.Business.Configurations.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {

            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
