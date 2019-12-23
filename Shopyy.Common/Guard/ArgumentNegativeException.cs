using System;

namespace Shopyy.Common.Guard
{
    public class ArgumentNegativeException : Exception
    {
        public ArgumentNegativeException(string arugumentName) : base($"{arugumentName} can't be negative")
        {

        }
    }
}
