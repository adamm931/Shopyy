using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;

namespace Shopyy.Products.Domain.Factories.Products
{
    public class ProductAttributeFactory
    {
        public static ProductAttribute ByType(ProductAttributeTypeId productAttributeTypeId, string value)
        {
            return productAttributeTypeId switch
            {
                ProductAttributeTypeId.Color => new ColorProductAttribute(value),
                ProductAttributeTypeId.Brand => new BrandProductAttribute(value),
                ProductAttributeTypeId.Size => new SizeProductAttribute(value),
                _ => null
            };
        }
    }
}
