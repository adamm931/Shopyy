using System;

namespace Shopyy.Products.Domain.Exceptions
{
    public class SkuSchemaPlaceholderNotFoundException : Exception
    {
        public SkuSchemaPlaceholderNotFoundException(string placeholder)
            : base($"Placeholder - {placeholder} is not found")
        {

        }
    }
}
