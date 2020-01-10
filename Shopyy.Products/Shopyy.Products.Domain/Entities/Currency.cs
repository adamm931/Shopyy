using Shopyy.Common.Guard;
using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using System;

namespace Shopyy.Products.Domain.Entities
{
    public class Currency : IEntity
    {
        public Guid Id { get; private set; }

        public CurrencyCode CurrencyCode { get; private set; }

        public CurrnecyCodeTypeId CurrnecyCodeTypeId { get; private set; }

        public decimal Factor { get; private set; }

        public string Description { get; private set; }

        public Currency(
            decimal factor,
            CurrnecyCodeTypeId currnecyCodeTypeId,
            string description)
        {
            Ensure.NonNegative(factor, nameof(factor));
            Ensure.EnumValueDefined(currnecyCodeTypeId, nameof(currnecyCodeTypeId));

            Id = Guid.NewGuid();

            Factor = factor;
            CurrnecyCodeTypeId = currnecyCodeTypeId;
            Description = description;
        }

        public Currency()
        {
        }

        public override string ToString()
        {
            return CurrnecyCodeTypeId.ToString();
        }
    }
}
