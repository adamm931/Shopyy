using Shopyy.Application.Abstractions.Repository;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using System;

namespace Shopyy.Products.Application
{
    public interface IProductsAppContext
    {
        IRepository<Guid, Product> Products { get; }

        IRepository<CurrnecyCodeTypeId, CurrencyCode> CurrencyCodes { get; }

        IRepository<Guid, Currency> Currencies { get; }
    }
}
