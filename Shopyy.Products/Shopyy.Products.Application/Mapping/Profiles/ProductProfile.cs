using AutoMapper;
using Shoppy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Common;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Entities;

namespace Shopyy.Products.Application.Mapping.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductVariant, ProductResponse>()
                .For(src => src.ProductId, dst => dst.Id)
                .For(src => src.Product.Name, dst => dst.Name)
                .For(src => src.Product.Description, dst => dst.Description)
                .For(src => src.Product.SerialNumber, dst => dst.SerialNumber)
                .Ignore(dst => dst.Price)
                .AfterMap(MapPriceWithCurrency);
        }

        private void MapPriceWithCurrency(
            ProductVariant source,
            ProductResponse response,
            ResolutionContext context)
        {
            var currency = context.GetItem<Currency>(AutoMapperParams.Currency);

            response.Price = new ProductPriceResponse
            {
                Amount = source.GetPriceForCurrency(currency),
                Currnecy = currency.ToString()
            };
        }
    }
}
