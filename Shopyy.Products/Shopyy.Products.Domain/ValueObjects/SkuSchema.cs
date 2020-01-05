using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Domain.Exceptions;
using System.Collections.Generic;

namespace Shopyy.Products.Domain.ValueObjects
{
    public class SkuSchema : ValueObject
    {
        private const string Name = "Name";

        private readonly string _schema;
        private readonly List<string> _segmentsProvided;

        private SkuSchema(string schema, List<string> segmentsProvider)
        {
            _schema = schema;
            _segmentsProvided = segmentsProvider;
        }

        public static SkuSchema Parse(string schema)
        {
            ValidateSchema(schema);

            return new SkuSchema(schema, new List<string>());
        }

        public Sku Sku
        {
            get
            {
                EnsureCanProviderSku();

                return new Sku(_schema);
            }
        }

        public SkuSchema SetColor(ColorTypeId color) => ReplacePlaceholder(ProductAttributeTypeId.Color, color.ToShortName());

        public SkuSchema SetBrand(BrandTypeId brand) => ReplacePlaceholder(ProductAttributeTypeId.Brand, brand.ToShortName());

        public SkuSchema SetSize(SizeTypeId size) => ReplacePlaceholder(ProductAttributeTypeId.Size, size.ToShortName());

        public SkuSchema SetName(string name) => ReplacePlaceholder(Name, name);

        private SkuSchema ReplacePlaceholder(ProductAttributeTypeId type, string value)
            => ReplacePlaceholder(type.ToString(), value);

        private SkuSchema ReplacePlaceholder(string name, string value)
        {
            var placeholder = AsPlaceholder(name);

            if (!_schema.Contains(placeholder))
            {
                throw new SkuSchemaPlaceholderNotFoundException(placeholder);
            }

            _segmentsProvided.Add(name);

            return new SkuSchema(
                _schema.Replace(placeholder, value),
                _segmentsProvided);
        }

        private void EnsureCanProviderSku()
        {
            EnsureSegment(ProductAttributeTypeId.Color);
            EnsureSegment(ProductAttributeTypeId.Brand);
            EnsureSegment(ProductAttributeTypeId.Color);
            EnsureSegment(Name);
        }

        private static void ValidateSchema(string input)
        {
            ValidateSegment(input, ProductAttributeTypeId.Color);
            ValidateSegment(input, ProductAttributeTypeId.Brand);
            ValidateSegment(input, ProductAttributeTypeId.Size);
            ValidateSegment(input, Name);
        }

        private static void ValidateSegment(string input, object name)
        {
            if (!input.Contains(AsPlaceholder(name.ToString())))
            {
                throw new SkuSchemaInvalidException($"{name.ToString()} segment is not present");
            }
        }

        private void EnsureSegment(object name)
        {
            if (!_segmentsProvided.Contains(name.ToString()))
            {
                throw new SkuSchemaSegementNotProvidedException(name.ToString());
            }
        }

        public static string AsPlaceholder(string value) => $"#{value}#";
    }
}
