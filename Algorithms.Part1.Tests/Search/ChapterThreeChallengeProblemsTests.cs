using System;
using System.Collections.Generic;
using Xunit;
using Algorithms.Part1.Search;


namespace Algorithms.Part1.Tests.Search
{
    public class ChapterThreeChapterThreeChallengeProblemsTests
    {
        [Theory]
        [InlineData(new int[] { 0 }, true)]
        [InlineData(new int[] { 5 }, false)]
        [InlineData(new int[] { 0, 3, 5, 6, 7 }, true)]
        [InlineData(new int[] { -1, 0, 1, 2, 3, 5 }, true)]
        [InlineData(new int[5] { -1, 0, 1, 2, 3 }, false)]
        [InlineData(new int[6] { -1, 0, 1, 2, 3, 4 }, false)]
        public void CheckIndexEqualsToTheValue_Tests(int[] input, bool expectedOutput)
        {
            // Act
            var actualOutput = ChapterThreeChallengeProblems.CheckIndexEqualsToTheValue(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData(new int[] { 0 }, true)]
        [InlineData(new int[] { 5 }, false)]
        [InlineData(new int[] { 0, 3, 5, 6, 7 }, true)]
        [InlineData(new int[] { -1, 0, 1, 2, 3, 5 }, true)]
        [InlineData(new int[5] { -1, 0, 1, 2, 3 }, false)]
        [InlineData(new int[6] { -1, 0, 1, 2, 3, 4 }, false)]
        public void CheckIndexEqualsToTheValueRecursive_Tests(int[] input, bool expectedOutput)
        {
            // Act
            var actualOutput = ChapterThreeChallengeProblems.CheckIndexEqualsToTheValueRecursive(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }


        [Fact]
        public void FindMaxInUnimodalArray_ZeroElementArray()
        {
            // Arrange
            int[] input = new int[0];

            // Act
            Action act = () => ChapterThreeChallengeProblems.FindMaxInUnimodalArray(input);
            var exception = Assert.Throws<ArgumentException>(act);

            // Assert
            Assert.Equal("Array needs to have two elements at least!", exception.Message);
        }

        public static IEnumerable<object[]> GetTestCasesForFindMaxInUnimodalArray()
        {
            yield return new object[] { new int[] { 1, 5, 2 }, 5 };
            yield return new object[] { new int[] { 1, 5, 2, 0 }, 5 };
            yield return new object[] { new int[] { 1, 5, 7, 6, 0 }, 7 };

            // 100-element array test case
            int[] largeArray = new int[100];
            for (int i = 0; i < 50; i++)
            {
                largeArray[i] = i;  // Increasing sequence from 0 to 49
            }
            for (int i = 50; i < 100; i++)
            {
                largeArray[i] = 99 - i;  // Decreasing sequence from 49 to 0
            }
            yield return new object[] { largeArray, 49 };
        }

        [Theory]
        [MemberData(nameof(GetTestCasesForFindMaxInUnimodalArray))]
        public void FindMaxInUnimodalArray_TestCases(int[] input, int expected)
        {
            // Act
            var actualOutput = ChapterThreeChallengeProblems.FindMaxInUnimodalArray(input);

            // Assert
            Assert.Equal((int)expected, actualOutput);
        }

        [Theory]
        [MemberData(nameof(GetTestCasesForFindMaxInUnimodalArray))]
        public void FindMaxInUnimodalArrayRecursive_TestCases(int[] input, int expected)
        {
            // Act
            var actualOutput = ChapterThreeChallengeProblems.FindMaxInUnimodalArrayRecursive(input);

            // Assert
            Assert.Equal((int)expected, actualOutput);
        }
    }
}
