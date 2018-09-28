using System;
using ReimplementingLinq;
using Xunit;

namespace ReimplementingLinqTests
{
    public class RangeTests
    {
        [Fact]
        public void CanMakeListInt()
        {
            var result = Enumerable.Range(6, 3);
            var expected = new int[] {6, 7, 8};
            Assert.Equal(result, expected);
        }

        [Fact]
        public void CanStartAtNegative()
        {
            var result = Enumerable.Range(-3, 2);
            var expected = new int[] { -3, -2 };
            Assert.Equal(result, expected);
        }

        [Fact]
        public void CountCantBeNegative()
        {
            Assert.Throws<ArgumentException>(() => Enumerable.Range(-3, -3));
        }

       [Fact]
        public void WillStopAtMaxValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(int.MaxValue, 3));
        }

        [Fact]
        public void MinValue0IsEmptyRange()
        {
            var result = Enumerable.Range(int.MinValue, 0);
            var expected = new int[] {  };
            Assert.Equal(result, expected);
        }
    }
}
