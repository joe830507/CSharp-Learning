using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CSharpLearning
{
    public static class DictionaryExtensions
    {
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(this IDictionary<TKey, TValue> srcDictionary)
        {
            return new ReadOnlyDictionary<TKey, TValue>(srcDictionary);
        }
    }

}
