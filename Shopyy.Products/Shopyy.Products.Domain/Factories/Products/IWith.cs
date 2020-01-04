using Shopyy.Products.Domain.Enumerations;

namespace Shopyy.Products.Domain.Factories.Products
{
    public interface IWithColor : IWithType<ColorTypeId>
    {
    }

    public interface IWithBrand : IWithType<BrandTypeId>
    {
    }

    public interface IWithSize : IWithType<SizeTypeId>
    {
    }

    public interface IWithType<TEnum> where TEnum : struct
    {
        public IBuildableProductAttribute HasValue(TEnum typeId);
    }
}
