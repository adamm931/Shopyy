using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Domain.Interfacaes;
using System.Collections.Generic;

namespace Shopyy.Infrastructure.Seed
{
    public class SeederData
    {
        public static IEnumerable<Product> GetProducts(ISkuProvider skuProvider)
        {
            // 1
            var p1 = new Product("A4 Tech Mouse 1", "Nice gaming mouse with 3200 DPI");

            var v11 = new ProductVariant(1900, 255)
                        .AddColor(ColorTypeId.Red)
                        .AddSize(SizeTypeId.Medium);

            var v12 = new ProductVariant(1900, 255)
                        .AddColor(ColorTypeId.Green)
                        .AddSize(SizeTypeId.ExtraLarge);

            v11.SetSku(skuProvider.GenerateSku(p1, v11).Result);
            v12.SetSku(skuProvider.GenerateSku(p1, v12).Result);

            p1.AddVariants(new[] { v11, v12 });

            // 2
            var p2 = new Product("A4 Tech Mouse 2", "Nice gaming mouse with 4200 DPI");

            var v21 = new ProductVariant(1900, 255)
                        .AddColor(ColorTypeId.Green)
                        .AddSize(SizeTypeId.ExtraLarge);

            var v22 = new ProductVariant(1900, 255)
                        .AddColor(ColorTypeId.White)
                        .AddSize(SizeTypeId.ExtraLarge);

            v21.SetSku(skuProvider.GenerateSku(p2, v21).Result);
            v22.SetSku(skuProvider.GenerateSku(p2, v22).Result);

            p2.AddVariants(new[] { v21, v22 });

            // 3
            var p3 = new Product("A4 Tech Mouse 3", "Nice gaming mouse with 5200 DPI");

            var v31 = new ProductVariant(1900, 255)
                        .AddColor(ColorTypeId.Green)
                        .AddBrand(BrandTypeId.A4Tech)
                        .AddSize(SizeTypeId.ExtraLarge);

            var v32 = new ProductVariant(1900, 255)
                        .AddColor(ColorTypeId.Blue)
                        .AddSize(SizeTypeId.ExtraLarge)
                        .AddBrand(BrandTypeId.Logitech);

            v31.SetSku(skuProvider.GenerateSku(p3, v31).Result);
            v32.SetSku(skuProvider.GenerateSku(p3, v32).Result);

            p3.AddVariants(new[] { v31, v32 });

            //4
            var p4 = new Product("A4 Tech Mouse 4", "Nice gaming mouse with 6200 DPI");

            var v41 = new ProductVariant(1900, 255)
                        .AddColor(ColorTypeId.Red)
                        .AddSize(SizeTypeId.Medium);

            var v42 = new ProductVariant(1900, 255)
                        .AddColor(ColorTypeId.Black)
                        .AddSize(SizeTypeId.Small);

            v41.SetSku(skuProvider.GenerateSku(p4, v41).Result);
            v42.SetSku(skuProvider.GenerateSku(p4, v42).Result);

            p4.AddVariants(new[] { v41, v42 });

            // 5
            var p5 = new Product("A4 Tech Mouse 5", "Nice gaming mouse with 7200 DPI");

            var v51 = new ProductVariant(2020, 115)
                        .AddColor(ColorTypeId.White)
                        .AddSize(SizeTypeId.Large);

            var v52 = new ProductVariant(2400, 135)
                        .AddColor(ColorTypeId.Cyan)
                        .AddBrand(BrandTypeId.Genius)
                        .AddSize(SizeTypeId.Medium);

            v51.SetSku(skuProvider.GenerateSku(p5, v51).Result);
            v52.SetSku(skuProvider.GenerateSku(p5, v52).Result);

            p5.AddVariants(new[] { v51, v52 });

            return new[] { p1, p2, p3, p4, p5 };
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
    }
}
