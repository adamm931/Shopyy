using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using System;

namespace Shopyy.Products.Domain.Factories.Products
{
    public interface IBuildableProductAttribute
    {
        ProductAttribute Build();
    }

    public class BuildableProductAttribute : IBuildableProductAttribute
    {
        public BuildableProductAttribute(ProductAttributeBuilder.Context context)
        {
            Context = context;
        }

        public ProductAttributeBuilder.Context Context { get; }

        public ProductAttribute Build()
        {
            if (!Context.IsValid)
            {
                throw new InvalidOperationException("Builder is in invalid state.");
            }

            return Context._type switch
            {
                ProductAttributeTypeId.Color => new ColorProductAttribute(Context._color.Value),
                ProductAttributeTypeId.Brand => new BrandProductAttribute(Context._brand.Value),
                ProductAttributeTypeId.Size => new SizeProductAttribute(Context._size.Value),
                _ => null
            };
        }
    }
}
