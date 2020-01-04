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
        public const string ProductAttributeTypes = "product_attribute_types";
        public const string CurrnecyCodes = "currency_codes";
        public const string Currencies = "currencies";
        public const string Colors = "color_types";
        public const string Brands = "brand_types";
        public const string Sizes = "size_types";
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
            public const string Sku = "sku";
            public const string StockCount = "stock_count";
            public const string ProductId = "product_id";
        }

        public class ProductAttribute
        {
            public const string Value = "value";
            public const string AttributeTypeId = "attribute_type_id";
            public const string VariantId = "variant_id";

            public class Color
            {
                public const string TypeId = "color_type_id";
            }

            public class Brand
            {
                public const string TypeId = "brand_type_id";
            }

            public class Size
            {
                public const string TypeId = "size_type_id";
            }
        }

        public class Currency
        {
            public const string CurrencyCodeId = "currency_code_id";
            public const string Factor = "factor";
            public const string Description = "description";
        }
    }
}
