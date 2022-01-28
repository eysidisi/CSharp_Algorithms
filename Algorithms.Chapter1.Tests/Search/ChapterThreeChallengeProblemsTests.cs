using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Search;


namespace Algorithms.Part1.Tests.Search
{
    public class ChapterThreeChallengeProblemsTests
    {
        [Theory]
        [InlineData(new int[] { 0 }, true)]
        [InlineData(new int[] { 5 }, false)]
        public void CheckIndexEqualsToTheValue_OneElementArray(int[] input, bool expectedOutput)
        {
            // Arrange
            ChapterThreeChallengeProblems challengeProblems = new ChapterThreeChallengeProblems();

            // Act
            var actualOutput = challengeProblems.CheckIndexEqualsToTheValue(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void CheckIndexEqualsToTheValue_FirstElementIsTrue()
        {
            // Arrange
            ChapterThreeChallengeProblems challengeProblems = new ChapterThreeChallengeProblems();
            var input = new int[] { 0, 3, 5, 6, 7 };
            // Act
            var actualOutput = challengeProblems.CheckIndexEqualsToTheValue(input);
            var expectedOutput = true;

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void CheckIndexEqualsToTheValue_LastElementIsTrue()
        {
            // Arrange
            ChapterThreeChallengeProblems challengeProblems = new ChapterThreeChallengeProblems();
            var input = new int[] { -1, 0, 1, 2, 3, 5 };
            // Act
            var actualOutput = challengeProblems.CheckIndexEqualsToTheValue(input);
            var expectedOutput = true;

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData(new int[5] { -1, 0, 1, 2, 3 }, false)]
        [InlineData(new int[6] { -1, 0, 1, 2, 3, 4 }, false)]
        public void CheckIndexEqualsToTheValue_NoCorrectElementIsFound(int[] input, bool expectedOutput)
        {
            // Arrange
            ChapterThreeChallengeProblems challengeProblems = new ChapterThreeChallengeProblems();

            // Act
            var actualOutput = challengeProblems.CheckIndexEqualsToTheValue(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FindMaxInUnimodalArray_ZeroElementArray()
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
        public void FindMaxInUnimodalArray_ThreeElementArray()
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
        public void FindMaxInUnimodalArray_FourElementArray()
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
        public void FindMaxInUnimodalArray_MiddleElementIsMaximum()
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
