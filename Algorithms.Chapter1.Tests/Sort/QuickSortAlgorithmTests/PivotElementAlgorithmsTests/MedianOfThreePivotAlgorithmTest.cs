using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms;

namespace Algorithms.Part1.Tests.Sort.QuickSortAlgorithmTests.PivotElementAlgorithmsTests
{
    public class MedianOfThreePivotAlgorithmTest
    {
        [Theory]
        [InlineData(new int[] { 2, 5, 1 })]
        [InlineData(new int[] { 2, 1, 5 })]
        public void ThreeElements_FirstElementMedian(int[] input)
        {
            // Arrange
            MedianOfThreePivotAlgorithm algorithm = new MedianOfThreePivotAlgorithm();
            var expectedIndex = 0;

            // Act
            var actualOutput = algorithm.FindPivotIndex(0, 2, ref input);

            // Assert
            Assert.Equal(expectedIndex, actualOutput);
        }

        [Theory]
        [InlineData(new int[] { 5, 2, 1 })]
        [InlineData(new int[] { 1, 2, 5 })]
        public void ThreeElements_MiddleElementMedian(int[] input)
        {
            // Arrange
            MedianOfThreePivotAlgorithm algorithm = new MedianOfThreePivotAlgorithm();
            var expectedIndex = 1;

            // Act
            var actualOutput = algorithm.FindPivotIndex(0, 2, ref input);

            // Assert
            Assert.Equal(expectedIndex, actualOutput);
        }

        [Theory]
        [InlineData(new int[] { 1, 5, 2 })]
        [InlineData(new int[] { 5, 1, 2 })]
        public void ThreeElements_LastElementMedian(int[] input)
        {
            // Arrange
            MedianOfThreePivotAlgorithm algorithm = new MedianOfThreePivotAlgorithm();
            var expectedIndex = 2;

            // Act
            var actualOutput = algorithm.FindPivotIndex(0, 2, ref input);

            // Assert
            Assert.Equal(expectedIndex, actualOutput);
        }

        [Fact]
        public void FourElements_MiddleElementMedian()
        {
            // Arrange
            MedianOfThreePivotAlgorithm algorithm = new MedianOfThreePivotAlgorithm();
            var input = new int[] { 1, 2, 3, 4 };
            var expectedIndex = 1;

            // Act
            var actualIndex = algorithm.FindPivotIndex(0, 3, ref input);

            // Assert
            Assert.Equal(expectedIndex, actualIndex);
        }

        [Fact]
        public void ThreeElements_ThrowsException()
        {
            // Arrange
            MedianOfThreePivotAlgorithm algorithm = new MedianOfThreePivotAlgorithm();
            var input = new int[] { 1, 5, 1 };
            var expectedIndex = 2;

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => algorithm.FindPivotIndex(0, 2, ref input));
        }

    }
}
