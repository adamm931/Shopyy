using Shoppy.Domain.Specification;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.ValueObjects;
using System.Linq;

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

        public ProductSpecification ForSku(Sku sku)
        {
            AddAnd(product => product
                .Variants
                .Any(variation => variation.Sku.Value == sku.Value));

            return this;
        }
    }
}
