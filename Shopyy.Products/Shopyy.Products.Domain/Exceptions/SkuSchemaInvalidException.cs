using System;

namespace Shopyy.Products.Domain.Exceptions
{
    public class SkuSchemaInvalidException : Exception
    {
        public SkuSchemaInvalidException(string message) : base(message)
        {
        }
    }
}
