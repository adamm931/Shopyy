﻿using Shopyy.Application.Interfaces;
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

        public IEnumerable<Variant> Variants { get; set; }

        public class Variant
        {
            public string Sku { get; set; }

            public int StockCount { get; set; }

            public decimal Amount { get; set; }

            public string Currency { get; set; }

            public IEnumerable<Attribute> Attributes { get; set; }

            public class Attribute : INameValueModel
            {
                public string Name { get; set; }

                public string Value { get; set; }
            }
        }
    }
}
