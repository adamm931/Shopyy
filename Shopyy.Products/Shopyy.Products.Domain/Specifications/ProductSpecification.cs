using Shoppy.Domain.Specification;
using Shopyy.Products.Domain.Entities;

namespace Shopyy.Products.Domain.Specifications
{
    public class ProductSpecification : Specification<Product>
    {
        public static ProductSpecification Create() => new ProductSpecification();

        public ProductSpecification IncludeVariations()
        {
            AddInclude(nameof(Product.Variants));
            AddInclude($"{nameof(Product.Variants)}.{nameof(ProductVariant.Attributes)}");

            return this;
        }
    }
}
