using System.Collections.Generic;

namespace Shopyy.Products.Application.Models.Request
{
    public class ProductVariantRequest
    {
        public decimal Price { get; set; }

        public int StockCount { get; set; }

        public IEnumerable<ProductAttributeRequest> Attributes { get; set; }
    }
}
