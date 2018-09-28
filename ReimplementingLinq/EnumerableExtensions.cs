using System;
using System.Collections.Generic;
using System.Text;

namespace ReimplementingLinq
{
    public static class Enumerable
    {
        public static IEnumerable<int> Range(int start, int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("Count");
            }

            if((long) start + (long)count > int.MaxValue)
                throw new ArgumentOutOfRangeException("Too big!");
            return RangeImp(start, count);
        }

        private static IEnumerable<int> RangeImp(int start, int count)
        {
            for (int i = start; i < start + count; i++)
            {
                yield return i;
            }
        }

        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            if(count < 0)
                throw new ArgumentOutOfRangeException("Count can't be zilch!");
            return RepeatImp(element, count);
        }

        private static IEnumerable<TResult> RepeatImp<TResult>(TResult element, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return element;
            }
        }
    }
}
