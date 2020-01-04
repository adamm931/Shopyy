using Shopyy.Products.Domain.Enumerations;

namespace Shopyy.Products.Domain.Factories.Products
{
    public interface IProductAttributeBuilder
    {
        IWithBrand ForBrand();

        IWithColor ForColor();

        IWithSize ForSize();
    }

    public class ProductAttributeBuilder : IProductAttributeBuilder
    {
        public class Context
        {
            public ProductAttributeTypeId? _type;
            public ColorTypeId? _color;
            public BrandTypeId? _brand;
            public SizeTypeId? _size;

            public bool IsValid => _type switch
            {
                ProductAttributeTypeId.Brand => _brand.HasValue,
                ProductAttributeTypeId.Color => _color.HasValue,
                ProductAttributeTypeId.Size => _size.HasValue,
                _ => false
            };

            public Context SetType(ProductAttributeTypeId type)
            {
                _type = type;
                return this;
            }

            public Context SetColor(ColorTypeId color)
            {
                _color = color;
                return this;
            }

            public Context SetBrand(BrandTypeId brand)
            {
                _brand = brand;
                return this;
            }

            public Context SetSize(SizeTypeId size)
            {
                _size = size;
                return this;
            }
        }

        private Context BuilderContext { get; }

        private ProductAttributeBuilder()
        {
            BuilderContext = new Context();
        }

        public static ProductAttributeBuilder New => new ProductAttributeBuilder();

        public IWithBrand ForBrand()
            => new With.Brand(BuilderContext.SetType(ProductAttributeTypeId.Brand));

        public IWithColor ForColor()
            => new With.Color(BuilderContext.SetType(ProductAttributeTypeId.Color));

        public IWithSize ForSize()
            => new With.Size(BuilderContext.SetType(ProductAttributeTypeId.Size));
    }
}
