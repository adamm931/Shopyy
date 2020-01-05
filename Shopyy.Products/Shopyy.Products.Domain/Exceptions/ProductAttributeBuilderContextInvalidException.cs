using System;

namespace Shopyy.Products.Domain.Exceptions
{
    public class ProductAttributeBuilderContextInvalidException : Exception
    {
        public ProductAttributeBuilderContextInvalidException(string message) : base(message)
        {
        }
    }
}
