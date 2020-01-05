using System;
using System.Collections.Generic;

namespace Shopyy.Products.Application.Models.Response
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long SerialNumber { get; set; }

        public IEnumerable<ProductVariantResponse> Variants { get; set; }
    }
}
