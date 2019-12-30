using Shopyy.Products.Domain.Entities;

namespace Shopyy.Products.Domain.DomainServices
{
    public interface IProductSkuGenerator
    {
        string GenerateSku(ProductVariant product);
    }
}
