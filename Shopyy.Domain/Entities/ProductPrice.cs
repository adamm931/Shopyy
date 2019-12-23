using Shopyy.Common.Guard;
using System;

namespace Shopyy.Domain.Entities
{
    public class ProductPrice
    {
        public decimal Amount { get; private set; }

        public string CurrencyCode { get; private set; }

        public ProductPrice(decimal amount, string currencyCode)
        {
            Ensure.NonNegative(amount, nameof(amount));
            Ensure.NotEmpty(currencyCode, nameof(currencyCode));

            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public bool HasCurrency(string currencyCode)
        {
            Ensure.NotEmpty(currencyCode, nameof(currencyCode));

            return CurrencyCode.Equals(currencyCode, StringComparison.OrdinalIgnoreCase);
        }
    }
}
