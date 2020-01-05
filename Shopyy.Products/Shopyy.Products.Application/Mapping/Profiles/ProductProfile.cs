using AutoMapper;
using Shoppy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Entities;

namespace Shopyy.Products.Application.Mapping.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>()
                .For(src => src.Variants, dst => dst.Variants);
        }
    }
}
