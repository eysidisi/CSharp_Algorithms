using Algorithms.Part1.Search.DSelectionAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Algorithms.Part1.Tests.Search.DSelectionAlgorithm
{
    public class DSelectionTests
    {
        [Fact]
        public void FindKthOrderStatistic_OneElementArr()
        {
            // Arrange
            DSelection dSelect = new DSelection();
            var input = new int[] { 1 };
            int expectedOutput = 1;
            int wantedIndex = 1;


            // Act
            var actualOutput = dSelect.FindOrderStatistic(input, wantedIndex);

            // Asssert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FindKthOrderStatistic_FourElementArr()
        {
            // Arrange
            DSelection dSelect = new DSelection();
            var input = new int[] { 4, 2, 1, 3 };
            int wantedIndex = 2;
            int expectedOutput = 2;

            // Act
            var actualOutput = dSelect.FindOrderStatistic(input, wantedIndex);

            // Asssert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FindKthOrderStatistic_FiveElementArr()
        {
            // Arrange
            DSelection dSelect = new DSelection();
            var input = new int[] { 4, 2, 1, 3, 5 };
            int wantedIndex = 3;
            int expectedOutput = 3;

            // Act
            var actualOutput = dSelect.FindOrderStatistic(input, wantedIndex);

            // Asssert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FindKthOrderStatistic_SixElementArr()
        {
            // Arrange
            DSelection dSelect = new DSelection();
            var input = new int[] { 4, 2, 1, 6, 3, 5 };
            int wantedIndex = 4;
            int expectedOutput = 4;

            // Act
            var actualOutput = dSelect.FindOrderStatistic(input, wantedIndex);

            // Asssert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FindKthOrderStatistic_ElevenElementArr()
        {
            // Arrange
            DSelection dSelect = new DSelection();
            var input = new int[] { 4, 2, 1, 6, 3, 5, 7, 8, 9, 10, 11 };
            int wantedIndex = 4;
            int expectedOutput = 4;

            // Act
            var actualOutput = dSelect.FindOrderStatistic(input, wantedIndex);

            // Asssert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData(500, 500)]
        [InlineData(501, 501)]
        [InlineData(499, 499)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(1000, 1000)]
        [InlineData(999, 999)]
        public void FindKthOrderStatistic_ThousandElementArr(int wantedIndex, int expectedOutput)
        {
            // Arrange
            DSelection dSelect = new DSelection();
            int numOfElements = 1000;
            var input = new int[numOfElements];
            for (int i = 0; i < numOfElements; i++)
            {
                input[i] = i + 1;
            }

            Random rnd = new Random(10);
            input = input.OrderBy(x => rnd.Next()).ToArray();

            // Act
            var actualOutput = dSelect.FindOrderStatistic(input, wantedIndex);

            // Asssert
            Assert.Equal(expectedOutput, actualOutput);
        }

    }
}
