using Shopyy.Domain;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace Shopyy.Infrastructure.Seed
{
    public class SeederData
    {
        public static IEnumerable<Product> GetProducts()
        {
            return new[]
            {
                new Product("A4-Tech-Mouse-1", "A4 Tech Mouse 1", "Nice gaming mouse with 3200 DPI", 1050, 10),
                new Product("A4-Tech-Mouse-2", "A4 Tech Mouse 2", "Nice gaming mouse with 4200 DPI", 1250, 15),
                new Product("A4-Tech-Mouse-3", "A4 Tech Mouse 3", "Nice gaming mouse with 5200 DPI", 2250, 20),
                new Product("A4-Tech-Mouse-4", "A4 Tech Mouse 4", "Nice gaming mouse with 6200 DPI", 3250, 12),
                new Product("A4-Tech-Mouse-5", "A4 Tech Mouse 5", "Nice gaming mouse with 7200 DPI", 4250, 11)
            };
        }

        public static IEnumerable<CurrencyCode> GetCurrencyCodes()
        {
            return GetEnumerationEntites<CurrencyCode, CurrnecyCodeTypeId>();
        }

        public static IEnumerable<Currency> GetCurrencies()
        {
            return new[]
            {
                new Currency(1.00m, CurrnecyCodeTypeId.EUR, "Euro"),
                new Currency(0.90m, CurrnecyCodeTypeId.USD, "Dollars"),
                new Currency(0.0085m, CurrnecyCodeTypeId.RSD, "Dinars")
            };
        }

        private static IEnumerable<TEnumEntity> GetEnumerationEntites<TEnumEntity, TEnum>()
            where TEnumEntity : EnumEntity<TEnum>
            where TEnum : struct
        {
            foreach (var value in Enum.GetValues(typeof(TEnum)))
            {
                yield return Activator.CreateInstance(typeof(TEnumEntity), value) as TEnumEntity;
            }
        }
    }
}
