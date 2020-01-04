namespace Shopyy.Products.Domain.Enumerations
{
    public enum ColorTypeId
    {
        Red = 1,
        Green,
        Blue,
        Black,
        White,
        Grey,
        Cyan
    }

    public static class ColorTypeExtensions
    {
        public static string ToShortName(this ColorTypeId color)
            => color switch
            {
                ColorTypeId.Red => "R",
                ColorTypeId.Green => "GRN",
                ColorTypeId.Blue => "BLU",
                ColorTypeId.Black => "BLA",
                ColorTypeId.White => "WHT",
                ColorTypeId.Grey => "GRY",
                ColorTypeId.Cyan => "CYN",
                _ => string.Empty
            };
    }
}
