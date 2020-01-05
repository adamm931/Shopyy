using AutoMapper;
using Shopyy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Mapping.Extensions;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Entities;
using System.Linq;

namespace Shopyy.Products.Application.Mapping.Profiles
{
    public class ProductDetailsProfile : Profile
    {
        public ProductDetailsProfile()
        {
            CreateMap<Product, ProductDetailsResponse>();

            CreateMap<ProductVariant, ProductDetailsResponse.Variant>()
                .Ignore(dst => dst.Prices)
                .AfterMap(MapPrices);

            this.AddProductAttributeToNameModelMap<ProductDetailsResponse.Variant.Attribute>();
        }

        private void MapPrices(ProductVariant source, ProductDetailsResponse.Variant destination, ResolutionContext context)
        {
            destination.Prices = context.GetCurrencies()
                .Select(currency => new ProductDetailsResponse.Variant.Price
                {
                    Amount = source.GetPriceForCurrency(currency),
                    Currency = currency.ToString()
                });
        }
    }
}
