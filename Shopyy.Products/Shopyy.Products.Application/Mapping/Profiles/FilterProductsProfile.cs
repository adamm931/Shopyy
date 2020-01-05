using AutoMapper;
using Shopyy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Mapping.Extensions;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Entities;

namespace Shopyy.Products.Application.Mapping.Profiles
{
    public class FilterProductsProfile : Profile
    {
        public FilterProductsProfile()
        {
            CreateMap<Product, ProductResponse>();

            CreateMap<ProductVariant, ProductResponse.Variant>()
               .For(src => src.Sku, dst => dst.Sku)
               .AfterMap(MapPriceWithCurrency);

            this.AddProductAttributeToNameModelMap<ProductResponse.Variant.Attribute>();
        }

        private void MapPriceWithCurrency(
            ProductVariant source,
            ProductResponse.Variant response,
            ResolutionContext context)
        {
            var currency = context.GetCurrency();

            response.Amount = source.GetPriceForCurrency(currency);
            response.Currency = currency.ToString();
        }
    }
}
