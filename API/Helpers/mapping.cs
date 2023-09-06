using System.Collections.Generic;
using API.Dto;
using AutoMapper;
using core.Enities;

namespace API.Helpers
{
    public class mapping : Profile
    {
        public mapping()
        {
            CreateMap<Product,ProductstoreturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o=> o.MapFrom<urlresolverimg>());

        }
    }
}