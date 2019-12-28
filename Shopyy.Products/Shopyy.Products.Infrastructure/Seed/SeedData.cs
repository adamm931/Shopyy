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
            yield return new Product("A4-Tech-Mouse-1", "A4 Tech Mouse 1", "Nice gaming mouse with 3200 DPI")
                .AddVariants(
                new ProductVariant(1200, 5)
                    .AddAttribute(
                        new ProductAttribute("Color", "black"),
                        new ProductAttribute("Size", "large")
                        ),
                new ProductVariant(1400, 15)
                    .AddAttribute(
                        new ProductAttribute("Color", "red"),
                        new ProductAttribute("Size", "small")
                        )
                    );

            yield return new Product("A4-Tech-Mouse-2", "A4 Tech Mouse 2", "Nice gaming mouse with 4200 DPI")
                .AddVariants(
                new ProductVariant(1300, 7)
                    .AddAttribute(
                        new ProductAttribute("Color", "green"),
                        new ProductAttribute("Size", "large")
                        ),
                new ProductVariant(1500, 17)
                    .AddAttribute(
                        new ProductAttribute("Color", "blue"),
                        new ProductAttribute("Size", "large")
                        )
                    );

            yield return new Product("A4-Tech-Mouse-3", "A4 Tech Mouse 3", "Nice gaming mouse with 5200 DPI")
                .AddVariants(
                new ProductVariant(1400, 18)
                    .AddAttribute(
                        new ProductAttribute("Color", "black"),
                        new ProductAttribute("Size", "large")
                        ),
                new ProductVariant(1850, 22)
                    .AddAttribute(
                        new ProductAttribute("Color", "cyan"),
                        new ProductAttribute("Size", "medium")
                        )
                    );

            yield return new Product("A4-Tech-Mouse-4", "A4 Tech Mouse 4", "Nice gaming mouse with 6200 DPI")
                .AddVariants(
                new ProductVariant(1525, 65)
                    .AddAttribute(
                        new ProductAttribute("Color", "black"),
                        new ProductAttribute("Size", "large")
                        ),
                new ProductVariant(1900, 255)
                    .AddAttribute(
                        new ProductAttribute("Color", "red"),
                        new ProductAttribute("Size", "small")
                        )
                    );

            yield return new Product("A4-Tech-Mouse-5", "A4 Tech Mouse 5", "Nice gaming mouse with 7200 DPI")
                .AddVariants(
                new ProductVariant(2020, 115)
                    .AddAttribute(
                        new ProductAttribute("Color", "dark gray"),
                        new ProductAttribute("Size", "extra large")
                        ),
                new ProductVariant(2400, 135)
                    .AddAttribute(
                        new ProductAttribute("Color", "light blue"),
                        new ProductAttribute("Size", "extra small")
                        )
                    );
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
                new Currency(1.10m, CurrnecyCodeTypeId.USD, "Dollars"),
                new Currency(118.55m, CurrnecyCodeTypeId.RSD, "Dinars")
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
