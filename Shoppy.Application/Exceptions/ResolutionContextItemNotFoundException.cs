using System;

namespace Shopyy.Application.Exceptions
{
    public class ResolutionContextItemNotFoundException : Exception
    {
        public ResolutionContextItemNotFoundException(string name) :
            base($"Item with name: {name} is not present in ResolutionContext.Items")
        {

        }
    }
}
