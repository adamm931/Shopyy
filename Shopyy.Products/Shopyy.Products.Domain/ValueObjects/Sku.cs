using Shopyy.Common.Guard;
using Shopyy.Domain;

namespace Shopyy.Products.Domain.ValueObjects
{
    public class Sku : ValueObject
    {
        public Sku(string value)
        {
            Ensure.NotEmpty(value, nameof(value));

            Value = value;
        }

        private Sku()
        {
        }

        public string Value { get; private set; }

        public static bool operator ==(Sku left, Sku right) => left.Value == right.Value;

        public static bool operator !=(Sku left, Sku right) => !(left == right);

        public override string ToString() => Value;
    }
}
