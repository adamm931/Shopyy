using Shopyy.Products.Domain.Enumerations;

namespace Shopyy.Products.Domain.Factories.Products
{
    public class With
    {
        public With(ProductAttributeBuilder.Context context)
        {
            Context = context;
        }

        public ProductAttributeBuilder.Context Context { get; }

        protected BuildableProductAttribute GoBuild(ProductAttributeBuilder.Context context)
            => new BuildableProductAttribute(context);

        public class Color : With, IWithColor
        {
            public Color(ProductAttributeBuilder.Context context) : base(context)
            { }

            public IBuildableProductAttribute HasValue(ColorTypeId typeId)
                => GoBuild(Context.SetColor(typeId));
        }

        public class Brand : With, IWithBrand
        {
            public Brand(ProductAttributeBuilder.Context context)
                : base(context)
            { }

            public IBuildableProductAttribute HasValue(BrandTypeId typeId)
                => GoBuild(Context.SetBrand(typeId));
        }

        public class Size : With, IWithSize
        {
            public Size(ProductAttributeBuilder.Context context)
                : base(context)
            { }

            public IBuildableProductAttribute HasValue(SizeTypeId typeId)
                => GoBuild(Context.SetSize(typeId));
        }
    }
}
