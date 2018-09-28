using System;
using System.Collections.Generic;
using System.Text;

namespace ReimplementingLinq
{
    public static class WhereExtensions
    {
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            if(predicate == null)
                throw new ArgumentNullException("predicate");

            return WhereImp(source, predicate);
        }

        public static IEnumerable<TSource> WhereImp<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }

        }


        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            int index = 0;
            foreach (T item in source)
            {
                if (predicate(item, index))
                {
                    yield return item;
                }

                index++;
            }
        }
    }
}
