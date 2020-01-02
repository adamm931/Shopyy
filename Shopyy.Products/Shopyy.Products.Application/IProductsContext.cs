using Shopyy.Application.Abstractions.Repository;
using Shopyy.Products.Domain.Entities;
using System;

namespace Shopyy.Products.Application
{
    public interface IProductsAppContext
    {
        IRepository<Guid, Product> Products { get; }

        IRepository<Guid, Currency> Currencies { get; }
    }
}
