using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Search;


namespace Algorithms.Part1.Tests.Search.ChapterThreeChallengeProblemsTests
{
    public class CheckIndexEqualsToTheValueTests
    {
        [Theory]
        [InlineData(new int[] { 0 }, true)]
        [InlineData(new int[] { 5 }, false)]
        public void OneElementArray(int[] input, bool expectedOutput)
        {
            // Arrange
            ChapterThreeChallengeProblems challengeProblems = new ChapterThreeChallengeProblems();

            // Act
            var actualOutput = challengeProblems.CheckIndexEqualsToTheValue(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FirstElementIsTrue()
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
        public void LastElementIsTrue()
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
        public void NoCorrectElementIsFound(int[] input, bool expectedOutput)
        {
            // Arrange
            ChapterThreeChallengeProblems challengeProblems = new ChapterThreeChallengeProblems();

            // Act
            var actualOutput = challengeProblems.CheckIndexEqualsToTheValue(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }


    }
}
