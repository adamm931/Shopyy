using System;
using System.Collections.Generic;

namespace Shopyy.Infrastructure.Interfaces
{
    public interface IEnumerationsProvider
    {
        IDictionary<Type, Type> GetEnumerationsDescriptor();
    }
}
