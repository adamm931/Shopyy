using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.ValueObjects;

namespace Shopyy.Products.Domain.Interfacaes
{
    public interface ISkuProvider
    {
        Sku GetSku(Product product, ProductVariant productVariant);
    }
}
