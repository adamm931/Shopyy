namespace Shopyy.Products.Domain.Builders.Products
{
    public interface IProductBuilder
    {
        IProductBuilder HasName(string name);

        IProductBuilder HasDescription(string description);

        IProductVariantBuilder Variants();
    }
}
