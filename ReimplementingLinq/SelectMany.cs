using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ReimplementingLinq
{
    public static class SelectManyExt
    {
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (TSource item in source)
            {
                foreach (TResult result in selector(item))
                {
                    yield return result;
                }
            }
        }
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this 
            IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TResult>> selector)
        {
            int index = 0;
            foreach (TSource item in source)
            {
                foreach (TResult result in selector(item, index++))
                {
                    yield return result;
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            foreach (var item in source)
            {
                foreach (var collItem in collectionSelector(item))
                {
                    yield return resultSelector(item, collItem);
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            int index = 0;
            foreach (var item in source)
            {
                foreach (var collItem in collectionSelector(item, index++))
                {
                    yield return resultSelector(item, collItem);
                }
            }
        }
    }
}
