using NUnit.Framework;
using System.Collections.Generic;

namespace Gonzo.Tests
{
    public class GonzoTests
    {
        [TestCase(new[] { 0, 0 }, 0)]
        [TestCase(new[] { 0, 1 }, 1)]
        [TestCase(new[] { 1, 0 }, 1)]
        [TestCase(new[] { 1, 1 }, 1)]
        [TestCase(new[] { 1, 1, 0, 1, 1 }, 4)]
        [TestCase(new[] { 1, 1, 0, 1, 1, 0, 1, 1, 1 }, 5)]
        [TestCase(new[] { 1, 1, 0, 1, 1, 0, 1, 1, 1, 0 }, 5)]
        public void Test_maxOnesAfterRemoveItem_withProvidedTestCases(IEnumerable<int> sequence, int expected)
        {
            var actual = -1;
            Assert.AreEqual(expected, actual);
        }
    }
}