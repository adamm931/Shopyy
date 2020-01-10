using Shopyy.Application.Abstractions.Repository;
using Shopyy.Products.Domain.Entities;
using System;

namespace Shopyy.Products.Application
{
    public interface IProductsAppContext
    {
        IRepository<Category> Categories { get; }

        IRepository<Currency> Currencies { get; }
    }
}
