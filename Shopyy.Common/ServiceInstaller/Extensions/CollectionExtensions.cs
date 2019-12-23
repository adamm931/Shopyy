using System;
using System.Collections.Generic;

namespace Shopyy.Common.ServiceInstaller.Extensions
{
    public static class CollectionExtensions
    {
        public static void ForEach<TElement>(this IEnumerable<TElement> items, Action<TElement> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}
