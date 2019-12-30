﻿using Shopyy.Application.Abstractions.Repository;
using Shopyy.Products.Application;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using System;

namespace Shopyy.Products.Infrastructure
{
    public class ProductsAppContext : IProductsAppContext
    {
        public ProductsAppContext(
            IRepository<Guid, Product> products,
            IRepository<CurrnecyCodeTypeId, CurrencyCode> currencyCodes,
            IRepository<Guid, Currency> currencies,
            IRepository<ProductAttributeTypeId, ProductAttributeType> productAttributeTypes
            )
        {
            Products = products;
            CurrencyCodes = currencyCodes;
            Currencies = currencies;
            ProductAttributeTypes = productAttributeTypes;
        }

        public IRepository<Guid, Product> Products { get; }

        public IRepository<CurrnecyCodeTypeId, CurrencyCode> CurrencyCodes { get; }

        public IRepository<Guid, Currency> Currencies { get; }

        public IRepository<ProductAttributeTypeId, ProductAttributeType> ProductAttributeTypes { get; }
    }
}
