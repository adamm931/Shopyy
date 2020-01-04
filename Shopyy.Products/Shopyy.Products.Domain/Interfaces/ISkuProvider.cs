using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Shopyy.Products.Domain.Interfacaes
{
    public interface ISkuProvider
    {
        Task<Sku> GenerateSku(Product product, ProductVariant productVariant);
    }
}
