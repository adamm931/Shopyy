using System.Collections.Generic;

namespace Shopyy.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddFrom<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> source)
        {
            foreach (var entry in source)
            {
                dictionary[entry.Key] = entry.Value;
            }
        }
    }
}
