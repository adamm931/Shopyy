using AutoMapper;
using Shoppy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Common;
using Shopyy.Products.Domain.Entities;

namespace Shopyy.Products.Application.Mapping.Extensions
{
    public static class AutoMapperExtensions
    {
        public static Currency GetCurrency(this ResolutionContext context)
            => context.GetItem<Currency>(AutoMapperParams.Currency);
    }
}
