using System;
using ReimplementingLinq;
using Xunit;

namespace ReimplementingLinqTests
{
    public class CountTests
    {
        [Fact]
        public void CorrectNumberReturned()
        {
            var a = new int[] { 1, 5, 2, 5 };
            var result = a.Count();
            Assert.Equal(4, result);
        }

        [Fact]
        public void CorrectNumberReturnedWithPredicate()
        {
            var a = new int[] {1, 5, 2, 5};
            var result = a.Count(x => x < 5);
            Assert.Equal(2, result);
        }

        [Fact]
        public void ArgumentExceptionIfSourcePredicateNull()
        {
            int[] a = null;
            Assert.Throws<ArgumentException>(() => a.Count(x => x < 5));
            var b = new int[] { 1, 5, 2, 5 };
            Func<int, bool> pred = null;
            Assert.Throws<ArgumentException>(() => b.Count(pred));
        }

    }
}
