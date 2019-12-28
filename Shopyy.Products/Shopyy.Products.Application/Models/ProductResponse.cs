using System;
using System.Collections.Generic;

namespace Shopyy.Products.Application.Models
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long SerialNumber { get; set; }

        public string ArticleNumber { get; set; }

        public IEnumerable<ProductAttributeResponse> Attributes { get; set; }

        public ProductPriceResponse Price { get; set; }

        public int StockCount { get; set; }
    }
}
