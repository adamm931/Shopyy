using Shopyy.Products.Domain.Enumerations;

namespace Shopyy.Products.Application.Models.Request
{
    public class ProductAttributeRequest
    {
        public ProductAttributeTypeId Type { get; set; }

        public string Value { get; set; }
    }
}
