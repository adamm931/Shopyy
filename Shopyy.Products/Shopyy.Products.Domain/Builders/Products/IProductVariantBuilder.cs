namespace Shopyy.Products.Domain.Builders.Products
{
    public interface IProductVariantBuilder
    {
        IProductVariantBuilder New();

        IProductVariantBuilder WithPrice(decimal price);

        IProductVariantBuilder WithStockCount(int stockCount);

        IProductAttributeBuilder Attributes();
    }
}
