using Shopyy.Products.Domain.Enumerations;

namespace Shopyy.Products.Application.Models.Request
{
    public class ProductAttributeRequest
    {
        public ProductAttributeTypeId Type { get; set; }

        public BrandTypeId? Brand { get; set; }

        public ColorTypeId? Color { get; set; }

        public SizeTypeId? Size { get; set; }
    }
}
