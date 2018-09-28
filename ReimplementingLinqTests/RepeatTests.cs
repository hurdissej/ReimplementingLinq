using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using ReimplementingLinq;
namespace ReimplementingLinqTests
{
    public class RepeatTests
    {
        [Fact]
        public void CanRepeatString()
        {
           var result = Enumerable.Repeat("Hello", 3);
            Assert.Equal(result, new []{ "Hello", "Hello", "Hello"});
        }

        [Fact]
        public void Repeat0Times()
        {
            var result = Enumerable.Repeat("Hello", 0);
            Assert.Equal(result, new string[]{ });
        }

        [Fact]
        public void RepeatNull()
        {
            object n = null;
            var result = Enumerable.Repeat(n, 3);
            Assert.Equal(result, new [] {n,n,n});
        }

        [Fact]
        public void NegativeCountThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Repeat("Hello", -2));
        }
    }
}
