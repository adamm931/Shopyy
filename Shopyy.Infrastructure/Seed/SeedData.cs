using Shopyy.Domain.Entities;
using System.Collections.Generic;

namespace Shopyy.Infrastructure.Seed
{
    public class SeederData
    {
        public static IEnumerable<Product> GetProducts()
        {
            var product1 = new Product("A4-Tech Mouse-1", "Nice gaming mouse with 3200 DPI");
            product1.AddPrice(1050, "USD");

            var product2 = new Product("A4-Tech Mouse-2", "Nice gaming mouse with 4200 DPI");
            product2.AddPrice(1250, "USD");

            var product3 = new Product("A4-Tech Mouse-3", "Nice gaming mouse with 5200 DPI");
            product3.AddPrice(2250, "USD");

            var product4 = new Product("A4-Tech Mouse-4", "Nice gaming mouse with 6200 DPI");
            product4.AddPrice(3250, "USD");

            var product5 = new Product("A4-Tech Mouse-5", "Nice gaming mouse with 7200 DPI");
            product5.AddPrice(4250, "USD");

            return new[]
            {
                product1, product2, product3, product4, product5
            };
        }
    }
}
