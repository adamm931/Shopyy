using System;

namespace Shopyy.Products.Domain.Exceptions
{
    public class SkuSchemaSegementNotProvidedException : Exception
    {
        public SkuSchemaSegementNotProvidedException(string segement) : base($"Segement {segement} is not provided")
        {
        }
    }
}
