using Shopyy.Domain.Specification;
using Shopyy.Products.Domain.Entities;
using System;

namespace Shopyy.Products.Domain.Specifications
{
    public class CategorySpecification : Specification<Category>
    {

        private static readonly string ProductsNav = nameof(Category.Products);
        private static readonly string ProductsVariantNav = $"{ProductsNav}.{nameof(Product.Variants)}";
        private static readonly string ProductsAttributesNav = $"{ProductsVariantNav}.{nameof(ProductVariant.Attributes)}";

        public static CategorySpecification Create() => new CategorySpecification();

        public CategorySpecification ById(Guid id)
        {
            AddAnd(category => category.Id == id);

            return this;
        }

        public CategorySpecification IncludeProducts()
        {
            AddInclude(ProductsNav);
            AddInclude(ProductsVariantNav);
            AddInclude(ProductsAttributesNav);

            return this;
        }
    }
}
