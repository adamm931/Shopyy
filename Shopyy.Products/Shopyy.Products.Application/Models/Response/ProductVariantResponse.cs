using System;
using System.Collections.Generic;

namespace Shopyy.Products.Application.Models.Response
{
    public class ProductVariantResponse
    {
        public Guid Id { get; set; }

        public string Sku { get; set; }

        public int StockCount { get; set; }

        public ProductPriceResponse Price { get; set; }

        public IEnumerable<ProductAttributeResponse> Attributes { get; set; }
    }
}
