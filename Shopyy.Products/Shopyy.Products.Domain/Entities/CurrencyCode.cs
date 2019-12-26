using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using System.Collections.Generic;

namespace Shopyy.Products.Domain.Entities
{
    public class CurrencyCode : EnumEntity<CurrnecyCodeTypeId>
    {
        public CurrencyCode(CurrnecyCodeTypeId @enum)
            : base(@enum)
        {
        }

        private CurrencyCode()
        {
        }

        public List<Currency> Currencies { get; private set; }
    }
}
