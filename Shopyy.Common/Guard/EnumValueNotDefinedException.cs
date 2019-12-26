using System;

namespace Shopyy.Common.Guard
{
    public class EnumValueNotDefinedException<TEnum> : Exception
        where TEnum : struct
    {
        public EnumValueNotDefinedException(TEnum value)
            : base($"Value: {value} is not defined for enum: {typeof(TEnum).Name }")
        {
        }
    }
}
