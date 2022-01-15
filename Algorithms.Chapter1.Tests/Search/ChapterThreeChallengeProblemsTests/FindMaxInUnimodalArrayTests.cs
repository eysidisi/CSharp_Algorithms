using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Part1.Search;
using Xunit;

namespace Algorithms.Part1.Tests.Search.ChapterThreeChallengeProblemsTests
{
    public class FindMaxInUnimodalArrayTests
    {
        [Fact]
        public void ZeroElementArray()
        {
            // Arrange
            ChapterThreeChallengeProblems challengeProblems = new ChapterThreeChallengeProblems();
            int[] input = new int[0];

            // Act
            Action act = () => challengeProblems.FindMaxInUnimodalArray(input);
            var exception = Assert.Throws<ArgumentException>(act);

            // Assert
            Assert.Equal("Array needs to have two elements at least!", exception.Message);
        }

        [Fact]
        public void ThreeElementArray()
        {
            // Arrange
            ChapterThreeChallengeProblems challengeProblems = new ChapterThreeChallengeProblems();
            int[] input = new int[3] { 1, 5, 2 };
            int expectedOutput = 5;

            // Act
            var actualOutput = challengeProblems.FindMaxInUnimodalArray(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FourElementArray()
        {
            // Arrange
            ChapterThreeChallengeProblems challengeProblems = new ChapterThreeChallengeProblems();
            int[] input = new int[] { 1, 5, 2, 0 };
            int expectedOutput = 5;

            // Act
            var actualOutput = challengeProblems.FindMaxInUnimodalArray(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void MiddleElementIsMaximum()
        {
            // Arrange
            ChapterThreeChallengeProblems challengeProblems = new ChapterThreeChallengeProblems();
            int[] input = new int[] { 1, 5, 7, 6, 0 };
            int expectedOutput = 7;

            // Act
            var actualOutput = challengeProblems.FindMaxInUnimodalArray(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

    }
}
