using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using System.Collections.Generic;

namespace Shopyy.Products.Domain.Entities
{
    public class ColorType : EnumEntity<ColorTypeId>
    {
        public ColorType(ColorTypeId color)
           : base(color)
        {
        }

        private ColorType()
        {
        }

        public IEnumerable<ColorProductAttribute> Attributes { get; private set; }
    }
}
