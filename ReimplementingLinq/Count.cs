using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ReimplementingLinq
{
    public static class CountExtensions
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentException("Null Source!");

            return source.CountImp();
        }
        public static int CountImp<TSource>(this IEnumerable<TSource> source)
        {
            if (source is ICollection<TSource> genCollection)
            {
                return genCollection.Count;
            }
            if (source is ICollection collection)
            {
                return collection.Count;
            }

            var count = 0;
            foreach (var item in source)
            {
                count++;
            }

            return count;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentException("Null Source!");
            if (predicate == null)
                throw new ArgumentException("Null predicate!");

            return source.CountImp(predicate);
        }

        private static int CountImp<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var count = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                    count++;
            }

            return count;
        }

        //This is just the same for LongCount
    }
}
