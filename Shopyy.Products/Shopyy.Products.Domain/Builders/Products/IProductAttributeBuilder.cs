using Shopyy.Products.Domain.Entities;

namespace Shopyy.Products.Domain.Builders.Products
{
    public interface IProductAttributeBuilder
    {
        IProductAttributeBuilder New();

        IProductAttributeBuilder WithName(string name);

        IProductAttributeBuilder WithValue(string value);

        Product Build();
    }
}
