using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using System.Collections.Generic;

namespace Shopyy.Products.Domain.Entities
{
    public class SizeType : EnumEntity<SizeTypeId>
    {
        public SizeType(SizeTypeId size)
           : base(size)
        {
        }

        private SizeType()
        {
        }

        public IEnumerable<SizeProductAttribute> Attributes { get; private set; }
    }
}
