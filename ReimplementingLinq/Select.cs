using System;
using System.Collections.Generic;

namespace ReimplementingLinq
{
    public static class SelectExtensions
    {
        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            return source.SelectImp(selector);
        }
        private static IEnumerable<TResult> SelectImp<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
    }
}
