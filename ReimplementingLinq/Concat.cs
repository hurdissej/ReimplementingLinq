using System;
using System.Collections.Generic;
using System.Text;

namespace ReimplementingLinq
{
    public static class ConcatExt
    {
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if(first == null || second == null)
                throw new ArgumentException();
            return ConcatImp(first, second);
        }

        private static IEnumerable<TSource> ConcatImp<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            foreach (TSource item in first)
            {
                yield return item;
            }

            foreach (TSource item in second)
            {
                yield return item;
            }
        }
    }
}
