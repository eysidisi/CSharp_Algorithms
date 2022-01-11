using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Chapter1.Count;

namespace Algorithms.Chapter1.Tests.Count
{
    public class CountInversionsTests
    {
        [Fact]
        public void NativeApproach_ArrayWithNoElement_ReturnsZero()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] input = new int[0];
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.NativeApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void NativeApproach_ArrayWithOneElement_ReturnsZero()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] input = new int[1];
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.NativeApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void NativeApproach_ArrayWithIncreasingElements_ReturnsZero()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] input = new int[] { 1, 2, 3, 4 };
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.NativeApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void NativeApproach_ArrayWithDecreasingElements_ReturnsInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] input = new int[] { 4, 3, 2, 1 };
            int expectedOutput = 6;

            // Act
            int actualOutput = countInversions.NativeApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void NativeApproach_ArrayWithIncreasingAndDecreasingElements_ReturnsInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] input = new int[] { 5, 6, 3, 4 };
            int expectedOutput = 4;

            // Act
            int actualOutput = countInversions.NativeApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
