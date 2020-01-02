using Shopyy.Domain;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Domain.Factories.Products;
using System;
using System.Collections.Generic;

namespace Shopyy.Infrastructure.Seed
{
    public class SeederData
    {
        public static IEnumerable<Product> GetProducts()
        {
            yield return new Product("A4 Tech Mouse 1", "Nice gaming mouse with 3200 DPI")
                .AddVariants(new[]
                {
                    new ProductVariant(1200, 5)
                        .AddAttributes(new[]
                        {
                           ProductAttributeFactory.ByType(ProductAttributeTypeId.Color, "black"),
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Size, "xxl")
                        }),
                    new ProductVariant(1400, 15)
                        .AddAttributes(new[]
                        {
                           ProductAttributeFactory.ByType(ProductAttributeTypeId.Color, "red"),
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Size, "s")
                        })
                });

            yield return new Product("A4 Tech Mouse 2", "Nice gaming mouse with 4200 DPI")
                .AddVariants(new[]
                {
                    new ProductVariant(1300, 7)
                        .AddAttributes(new[]
                        {
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Color, "green"),
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Size, "l")
                        }),
                    new ProductVariant(1500, 17)
                        .AddAttributes(new[] {
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Color, "blue"),
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Color,"l")
                        })
                });

            yield return new Product("A4 Tech Mouse 3", "Nice gaming mouse with 5200 DPI")
                .AddVariants(new[] {

                new ProductVariant(1400, 18)
                    .AddAttributes(new [] {
                        ProductAttributeFactory.ByType(ProductAttributeTypeId.Color, "black"),
                        ProductAttributeFactory.ByType(ProductAttributeTypeId.Size, "l")
                        }),
                new ProductVariant(1850, 22)
                    .AddAttributes(new [] {
                        ProductAttributeFactory.ByType(ProductAttributeTypeId.Color, "cyan"),
                        ProductAttributeFactory.ByType(ProductAttributeTypeId.Size, "m")
                        })
                    });

            yield return new Product("A4 Tech Mouse 4", "Nice gaming mouse with 6200 DPI")
                .AddVariants(new[]
                {
                    new ProductVariant(1525, 65)
                        .AddAttributes(new[]
                        {
                           ProductAttributeFactory.ByType(ProductAttributeTypeId.Color, "black"),
                           ProductAttributeFactory.ByType(ProductAttributeTypeId.Size, "l")
                        }),
                    new ProductVariant(1900, 255)
                        .AddAttributes(new[]
                        {
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Color, "red"),
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Size, "s")
                        })
                });

            yield return new Product("A4 Tech Mouse 5", "Nice gaming mouse with 7200 DPI")
                .AddVariants(new[]
                {
                    new ProductVariant(2020, 115)
                        .AddAttributes(new []
                        {
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Color, "red"),
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Size, "xl")
                        }),
                    new ProductVariant(2400, 135)
                        .AddAttributes(new []
                        {
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Color, "light blue"),
                            ProductAttributeFactory.ByType(ProductAttributeTypeId.Size, "xs")
                        })
                });
        }

        public static IEnumerable<CurrencyCode> GetCurrencyCodes()
        {
            return GetEnumerationEntites<CurrencyCode, CurrnecyCodeTypeId>();
        }

        public static IEnumerable<ProductAttributeType> GetProductAttributeTypes()
        {
            return GetEnumerationEntites<ProductAttributeType, ProductAttributeTypeId>();
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
