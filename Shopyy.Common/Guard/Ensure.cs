using System;

namespace Shopyy.Common.Guard
{
    public class Ensure
    {
        public static void NotEmpty(string argument, string arugmentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullException(arugmentName);
            }
        }

        public static void NotEmpty(Guid argument, string arugmentName)
        {
            if (argument == Guid.Empty)
            {
                throw new ArgumentNullException(arugmentName);
            }
        }

        public static void EnumValueDefined<TEnum>(TEnum argument, string arugmentName)
            where TEnum : struct
        {
            if (!Enum.IsDefined(typeof(TEnum), argument))
            {
                throw new EnumValueNotDefinedException<TEnum>(argument);
            }
        }

        public static void NotNull(object argument, string arugmentName)
        {
            if (argument == null)
            {
                throw new ArgumentNegativeException(arugmentName);
            }
        }

        public static void NonNegative(decimal argument, string arugmentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNegativeException(arugmentName);
            }
        }
    }
}
