using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ReimplementingLinq;
//using System.Linq;
using Xunit;

namespace ReimplementingLinqTests
{
    public class SelectManyTests
    {

        [Fact]
        public void SimpleFlatten()
        {
            int[] numbers = { 3, 5, 20, 15 };
            // The ToCharArray is unnecessary really, as string implements IEnumerable<char>
            var query = numbers.SelectMany((x) => x.ToString());
           var a = new Char[] {'3', '5', '2', '0', '1', '5'};
            Assert.Equal(query, a);
        }

        [Fact]
        public void SimpleFlattenWithIndex()
        {
            int[] numbers = { 3, 5, 20, 15 };
            // The ToCharArray is unnecessary really, as string implements IEnumerable<char>
            var query = numbers.SelectMany((x, index) => (x + index).ToString());
            var a = new Char[] { '3', '6', '2', '2', '1', '8' };
            Assert.Equal(query, a);
        }
        [Fact]
        public void CorrectlySelectsOutAList()
        {
            List<List<int>> numbers = new List<List<int>> { new List<int>{1,4}, new  List<int> { 5, 8 } };
            var query = numbers.SelectMany(collectionSelector: x => x.Where(y => y < 8), resultSelector: (x, c) => c * 2);
            var output = new int[] { 2, 8 , 10 };
            Assert.Equal(query, output);

        }

        [Fact]
        public void CorrectlySelectsOutAListWithINdex()
        {
            List<List<int>> numbers = new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 5, 8 } };
            var query = numbers.SelectMany(collectionSelector: (x, index) => x.Where(y => y - index < 8), resultSelector: (x, c) => c * 2);
            var output = new int[] { 2, 8, 10, 16 };
            Assert.Equal(query, output);

        }
    }
}
