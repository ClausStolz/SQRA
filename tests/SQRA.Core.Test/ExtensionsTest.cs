using System.Collections.Generic;
using NUnit.Framework;
using SQRA.Infrastructure.Extensions;


namespace SQRA.Core.Test
{
    [TestFixture]
    public class ExtensionsTest
    {
        [TestCase(new[] {1, 3, 5, 7, 9}, 4, 2)]
        [TestCase(new[] {5, 3, 5, 7, 9}, 4, 0)]
        [TestCase(new[] {5, 3, 5, 7, 9}, 10, -1)]
        public void GetFirstIndexTest(IList<int> obj, int value, int expectedIndex)
        {
            Assert.AreEqual(
                expectedIndex, 
                obj.GetFirstIndex<int>(x => x >= value)
            );
        }
    }
}   