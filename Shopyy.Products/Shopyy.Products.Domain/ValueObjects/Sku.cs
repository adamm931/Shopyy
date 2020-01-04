using Shoppy.Domain;
using Shopyy.Common.Guard;
using System.Collections.Generic;

namespace Shopyy.Products.Domain.ValueObjects
{
    public class Sku : ValueObject
    {
        public const string Separator = "-";

        // TODO: Make schema logic for skus. This means that skus has predefined order of segements
        public const string Schema = "{Name}{?Color}{?Brand}{?Size}{?Count}";

        public Sku(string value)
        {
            Ensure.NotEmpty(value, nameof(value));

            Value = value;
        }

        private Sku()
        {
        }

        public string Value { get; private set; }

        public IEnumerable<string> Segmenets => Value.Split(Separator);

        public Sku AppendSegment(string segmentValue) => new Sku($"{this}{Separator}{segmentValue}");

        public static implicit operator Sku(string value) => new Sku(value);

        public static bool operator ==(Sku left, Sku right) => left.Value == right.Value;

        public static bool operator !=(Sku left, Sku right) => !(left == right);

        public override string ToString() => Value;
    }
}
