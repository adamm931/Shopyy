using Shopyy.Application.Abstractions.Repository;
using Shopyy.Products.Application;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using System;

namespace Shopyy.Products.Infrastructure
{
    public class ProductsAppContext : IProductsAppContext
    {
        public ProductsAppContext(
            IRepository<Currency> currencies,
            IRepository<Category> categories
            )
        {
            Currencies = currencies;
            Categories = categories;
        }

        public IRepository<Category> Categories { get; }

        public IRepository<Currency> Currencies { get; }
    }
}
