using Shopyy.Infrastructure.Configurations;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Infrastructure.Common;

namespace Shopyy.Products.Infrastructure.Configurations
{
    public class CurrencyCodeConfiguration : EnumerationConfiguration<CurrencyCode, CurrnecyCodeTypeId>
    {
        public CurrencyCodeConfiguration() : base(Tables.CurrnecyCodes)
        {
        }
    }
}
