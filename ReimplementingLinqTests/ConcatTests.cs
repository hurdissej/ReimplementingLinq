using System;
using System.Collections.Generic;

using ReimplementingLinq;
using System.Text;
using Xunit;

namespace ReimplementingLinqTests
{
    public class ConcatTests
    {
        [Fact]
        public void TwoSequencesAreConcatenated()
        {
            var a = new string[] {"Hello "};
            var b = new string[] {"World"};
            var result = a.Concat(b);
            Assert.Equal(result, new string[]{"Hello ", "World"});
        }

        [Fact]
        public void ArgumentsCantBeNull()
        {
            string[] a = null;
            string[] b = null;
            Assert.Throws<ArgumentException>(() => a.Concat(b));
        }

    }
}
