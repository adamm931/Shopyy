using AutoMapper;
using Shoppy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Mapping.Extensions;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Entities;

namespace Shopyy.Products.Application.Mapping.Profiles
{
    public class ProductVariantProfile : Profile
    {
        public ProductVariantProfile()
        {
            CreateMap<ProductVariant, ProductVariantResponse>()
                .For(src => src.Sku, dst => dst.Sku)
                .Ignore(dst => dst.Price)
                .AfterMap(MapPriceWithCurrency);
        }

        private void MapPriceWithCurrency(
            ProductVariant source,
            ProductVariantResponse response,
            ResolutionContext context)
        {
            var currency = context.GetCurrency();

            response.Price = new ProductPriceResponse
            {
                Amount = source.GetPriceForCurrency(currency),
                Currnecy = currency.ToString()
            };
        }
    }
}
