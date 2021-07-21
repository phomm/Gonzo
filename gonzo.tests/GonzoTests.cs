using NUnit.Framework;
using System.Collections.Generic;

namespace Gonzo.Tests
{
    using Gonzo.Lib;
    public class GonzoTests
    {
        [TestCase(new[] { 0, 0 }, 0)]
        [TestCase(new[] { 0, 1 }, 1)]
        [TestCase(new[] { 1, 0 }, 1)]
        [TestCase(new[] { 1, 1 }, 1)]
        [TestCase(new[] { 1, 1, 0, 1, 1 }, 4)]
        [TestCase(new[] { 1, 1, 0, 1, 1, 0, 1, 1, 1 }, 5)]
        [TestCase(new[] { 1, 1, 0, 1, 1, 0, 1, 1, 1, 0 }, 5)]
        public void Test_maxOnesAfterRemoveItem_withProvidedTestCases(IEnumerable<int> candidate, int expected)
        {
            var sequence = new SequenceOfZeroesOnes(candidate);
            var actual = sequence.CalculateMaxOnesAfterRemoveItem();
            Assert.AreEqual(expected, actual);
        }
    }
}