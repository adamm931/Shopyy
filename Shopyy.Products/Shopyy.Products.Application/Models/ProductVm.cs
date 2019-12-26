﻿using System;

namespace Shopyy.Products.Application.Models
{
    public class ProductVm
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long SerialNumber { get; set; }

        public string ArticleNumber { get; set; }

        public ProductPriceVm Price { get; set; }

        public int StockCount { get; set; }
    }
}
