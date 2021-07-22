using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Gonzo.Tests
{
    using Gonzo.Lib;
    public class SequenceOfZeroesOnesTests
    {

        private static IEnumerable<(IEnumerable<int>, int)> ProvidedTestCases()
        {
            yield return (new[] { 0, 0 }, 0);
            yield return (new[] { 0, 1 }, 1);
            yield return (new[] { 1, 0 }, 1);
            yield return (new[] { 1, 1 }, 1);
            yield return (new[] { 1, 1, 0, 1, 1 }, 4);
            yield return (new[] { 1, 1, 0, 1, 1, 0, 1, 1, 1 }, 5);
            yield return (new[] { 1, 1, 0, 1, 1, 0, 1, 1, 1, 0 }, 5);
        }

        private static IEnumerable<(IEnumerable<int>, int)> CustomTestCases()
        {
            yield return (new[] { 0, 1, 1, 0, 1 }, 3);
            yield return (new[] { 1, 0, 1 }, 2);
            yield return (new[] { 1, 0, 0, 1 }, 1);
            yield return (new[] { 1, 1, 0, 0, 1 }, 2);
            yield return (new[] { 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1 }, 6);
            yield return (new[] { 1, 1, 1, 1, 1, 0, 1, 1, 1 }, 8);
            yield return (new[] { 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 }, 9);
        }

        [TestCaseSource(nameof(ProvidedTestCases))]
        public void Test_maxOnesAfterRemoveItemByStateMachine_withProvidedTestCases((IEnumerable<int> candidate, int expected) testCase)
        {
            Test_maxOnesAfterRemoveItemByStateMachine(testCase.candidate, testCase.expected);
        }

        [TestCaseSource(nameof(CustomTestCases))]
        public void Test_maxOnesAfterRemoveItemByStateMachine_withCustomTestCases((IEnumerable<int> candidate, int expected) testCase)
        {
            Test_maxOnesAfterRemoveItemByStateMachine(testCase.candidate, testCase.expected);
        }

        private void Test_maxOnesAfterRemoveItemByStateMachine(IEnumerable<int> candidate, int expected)
        {
            var sequence = new SequenceOfZeroesOnes(candidate);
            var actual = sequence.MaxOnesAfterRemoveItemByStateMachine();
            Assert.AreEqual(expected, actual);
        }
    }
}