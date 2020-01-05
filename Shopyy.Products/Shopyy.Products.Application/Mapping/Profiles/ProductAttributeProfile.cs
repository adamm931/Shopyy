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
                .For(src => src.AttributeTypeId, dst => dst.Name)
                .Include<ColorProductAttribute, ProductAttributeResponse>()
                .Include<BrandProductAttribute, ProductAttributeResponse>()
                .Include<SizeProductAttribute, ProductAttributeResponse>()
                ;

            CreateMap<ColorProductAttribute, ProductAttributeResponse>()
                .For(src => src.ColorTypeId, dst => dst.Value);

            CreateMap<BrandProductAttribute, ProductAttributeResponse>()
                .For(src => src.BrandTypeId, dst => dst.Value);

            CreateMap<SizeProductAttribute, ProductAttributeResponse>()
                .For(src => src.SizeTypeId, dst => dst.Value);
        }
    }
}
