using Shopyy.Infrastructure.Configurations;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Infrastructure.Common;

namespace Shopyy.Products.Infrastructure.Configurations
{
    public class ProductAttributeTypeConfiguration : EnumerationConfiguration<ProductAttributeType, ProductAttributeTypeId>
    {
        public ProductAttributeTypeConfiguration() : base(Tables.ProductAttributeTypes)
        {
        }
    }
}
