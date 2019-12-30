using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using System.Collections.Generic;

namespace Shopyy.Products.Domain.Entities
{
    public class ProductAttributeType : EnumEntity<ProductAttributeTypeId>
    {
        public ProductAttributeType(ProductAttributeTypeId type)
            : base(type)
        {
        }

        private ProductAttributeType()
        {
        }

        public List<ProductAttribute> Attributes { get; private set; }

    }
}
