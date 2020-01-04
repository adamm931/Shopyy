namespace Shopyy.Products.Domain.Enumerations
{
    public enum SizeTypeId
    {
        Small = 1,
        Medium,
        Large,
        ExtraLarge
    }

    public static class SizeTypeExtensions
    {
        public static string ToShortName(this SizeTypeId sizeTypeId)
            => sizeTypeId switch
            {
                SizeTypeId.Small => "SM",
                SizeTypeId.Medium => "MID",
                SizeTypeId.Large => "LRG",
                SizeTypeId.ExtraLarge => "ELRG",
                _ => string.Empty
            };
    }
}
