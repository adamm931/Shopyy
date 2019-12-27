using Shoppy.Domain.Specification;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;

namespace Shopyy.Products.Domain.Specifications
{
    public class CurrencySpecification : Specification<Currency>
    {
        public static CurrencySpecification Create() => new CurrencySpecification();

        public CurrencySpecification IncludeCurrencyCode()
        {
            AddInclude(currency => currency.CurrencyCode);

            return this;
        }

        public CurrencySpecification ForCurrencyCodeType(CurrnecyCodeTypeId currencyCode)
        {
            AddAnd(currency => currency.CurrnecyCodeTypeId == currencyCode);

            return this;
        }
    }
}
