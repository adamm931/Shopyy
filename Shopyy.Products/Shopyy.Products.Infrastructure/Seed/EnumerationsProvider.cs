using Shopyy.Infrastructure.Interfaces;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace Shopyy.Products.Infrastructure.Seed
{
    public class EnumerationsProvider : IEnumerationsProvider
    {
        public IDictionary<Type, Type> GetEnumerationsDescriptor()
        {
            return new Dictionary<Type, Type>
            {
                { typeof(CurrnecyCodeTypeId), typeof(CurrencyCode) },
                { typeof(ProductAttributeTypeId), typeof(ProductAttributeType) }
            };
        }
    }
}
