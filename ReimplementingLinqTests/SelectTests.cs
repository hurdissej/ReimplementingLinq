using System;
using System.Collections.Generic;
using System.Text;

using ReimplementingLinq;
using Xunit;

namespace ReimplementingLinqTests
{
    public class SelectTests
    {
        [Fact]
        public void CanSelectElements()
        {
            int[] source = { 1, 4, 2 };
            var result = source.Select(x => x);
            Assert.Equal(source, result);
        }

        [Fact]
        public void CanPerformDelegate()
        {
            int[] source = { 1, 4, 2 };
            var result = source.Select(x => x.ToString());
            var expected = new[] { "1", "4", "2" };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ThrowsOnNullArgument()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Select(predicate));
        }

        [Fact]
        public void ThrowsOnNullSource()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Select(x => x));
        }

        [Fact]
        public void WhereAndSelectQuery()
        {
            int[] source = { 1, 4, 2 };
            var result = from x in source
                         where x < 4
                         select x * 2;
            Assert.Equal(new []{2,4}, result);
        }
    }
}
