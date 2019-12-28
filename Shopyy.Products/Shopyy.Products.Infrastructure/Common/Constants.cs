namespace Shopyy.Products.Infrastructure.Common
{
    public class AppSettings
    {
        public const string MongoDatabaseOptions = "MongoDatabaseOptions";
        public const string ProductsCatalogueDatabaseOptions = "ProductsCatalogueDatabaseOptions";
    }

    public class Tables
    {
        public const string Products = "products";
        public const string ProductVariants = "product_variants";
        public const string ProductAttributes = "product_attributes";
        public const string CurrnecyCodes = "currency_codes";
        public const string Currencies = "currencies";
    }

    public class Sequnces
    {
        public const string ProductSerialNumber = "product_serial_number";
        public const int ProductSerialStart = 100000;
    }

    public class Columns
    {
        public class Product
        {
            public const string SerialNumber = "serial_number";
            public const string ArticleNumber = "article_number";
            public const string Description = "description";
        }

        public class ProductVariant
        {
            public const string Price = "price";
            public const string StockCount = "stock_count";
            public const string ProductId = "product_id";
        }

        public class ProductAttribute
        {
            public const string Value = "value";
            public const string VariantId = "variant_id";
        }

        public class Currency
        {
            public const string CurrencyCodeId = "currency_code_id";
            public const string Factor = "factor";
            public const string Description = "description";
        }
    }
}
