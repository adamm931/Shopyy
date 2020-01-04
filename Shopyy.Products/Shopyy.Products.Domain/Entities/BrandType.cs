using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using System.Collections.Generic;

namespace Shopyy.Products.Domain.Entities
{
    public class BrandType : EnumEntity<BrandTypeId>
    {
        public BrandType(BrandTypeId brand)
           : base(brand)
        {
        }

        private BrandType()
        {
        }

        public IEnumerable<BrandProductAttribute> Attributes { get; private set; }
    }
}
