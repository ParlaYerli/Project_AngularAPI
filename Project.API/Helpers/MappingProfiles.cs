using AutoMapper;
using Project.API.Dtos;
using Project.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductBrand, y => y.MapFrom(z => z.ProductBrand.Name))
                .ForMember(x => x.ProductType, y => y.MapFrom(z => z.ProductType.Name))
                .ForMember(x => x.PictureUrl, y => y.MapFrom<ProductUrlResolver>());
        }
    }
}
