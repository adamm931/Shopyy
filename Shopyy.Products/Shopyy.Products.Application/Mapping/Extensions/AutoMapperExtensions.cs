using AutoMapper;
using Shopyy.Application.Interfaces;
using Shopyy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Common;
using Shopyy.Products.Domain.Entities;
using System.Collections.Generic;

namespace Shopyy.Products.Application.Mapping.Extensions
{
    public static class AutoMapperExtensions
    {
        public static Currency GetCurrency(this ResolutionContext context)
            => context.GetItem<Currency>(AutoMapperParams.Currency);

        public static IEnumerable<Currency> GetCurrencies(this ResolutionContext context)
            => context.GetItem<IEnumerable<Currency>>(AutoMapperParams.Currencies);

        public static void AddProductAttributeToNameModelMap<TModel>(this Profile profile)
            where TModel : INameValueModel
        {
            profile.CreateMap<ProductAttribute, TModel>()
                .For(src => src.AttributeTypeId, dst => dst.Name)
                .Include<ColorProductAttribute, TModel>()
                .Include<BrandProductAttribute, TModel>()
                .Include<SizeProductAttribute, TModel>();

            profile.CreateMap<ColorProductAttribute, TModel>()
                .For(src => src.ColorTypeId, dst => dst.Value);

            profile.CreateMap<BrandProductAttribute, TModel>()
                .For(src => src.BrandTypeId, dst => dst.Value);

            profile.CreateMap<SizeProductAttribute, TModel>()
                .For(src => src.SizeTypeId, dst => dst.Value);
        }
    }
}
