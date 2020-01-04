namespace Shopyy.Products.Domain.Enumerations
{
    public enum BrandTypeId
    {
        A4Tech = 1,
        Logitech,
        Genius,
        Microsoft
    }

    public static class BrandTypeExtensions
    {
        public static string ToShortName(this BrandTypeId brand)
            => brand switch
            {
                BrandTypeId.A4Tech => "A4T",
                BrandTypeId.Logitech => "LGT",
                BrandTypeId.Genius => "GEN",
                BrandTypeId.Microsoft => "MCS",
                _ => string.Empty
            };
    }
}
