using AutoMapper;
using Shoppy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Entities;

namespace Shopyy.Products.Application.Mapping.Profiles
{
    public class ProductAttributeProfile : Profile
    {
        public ProductAttributeProfile()
        {
            CreateMap<ProductAttribute, ProductAttributeResponse>()
                .For(src => src.AttributeTypeId, dst => dst.Name);
        }
    }
}
