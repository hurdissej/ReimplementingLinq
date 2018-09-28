using System;
using System.Collections.Generic;
using ReimplementingLinq;
using Xunit;

namespace ReimplementingLinqTests
{
    public class WhereTests
    {
        [Fact]
        public void Where_FiltersList()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = source.Where(x => x < 4);
            Assert.Equal(result, new[] { 1, 3, 2, 1 });
        }

        [Fact]
        public void Where_NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(x => x > 5));
        }

        [Fact]
        public void Where_NullPredicateThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Fact]
        public void Where_FiltersListWithQueryExpression()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = from x in source
                         where x < 4
                         select x;
            Assert.Equal(result, new[] { 1, 3, 2, 1 });
        }
    }
}
