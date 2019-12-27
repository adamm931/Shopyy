using Shoppy.Domain.Specification;
using Shopyy.Products.Domain.Entities;

namespace Shopyy.Products.Domain.Specifications
{
    public class ProductSpecification : Specification<Product>
    {
        public static ProductSpecification Create() => new ProductSpecification();
    }
}
