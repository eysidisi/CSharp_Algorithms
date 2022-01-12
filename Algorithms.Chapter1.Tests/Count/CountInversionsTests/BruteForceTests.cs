using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Chapter1.Count;

namespace Algorithms.Chapter1.Tests.Count.CountInversionsTests
{
    public class BruteForceTests
    {
        [Fact]
        public void helperMethodsArrayWithNoElement_ReturnsZero()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] input = new int[0];
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.BruteForceApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void helperMethodsArrayWithOneElement_ReturnsZero()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] input = new int[1];
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.BruteForceApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void helperMethodsArrayWithIncreasingElements_ReturnsZero()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] input = new int[] { 1, 2, 3, 4 };
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.BruteForceApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void helperMethodsArrayWithDecreasingElements_ReturnsInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] input = new int[] { 4, 3, 2, 1 };
            int expectedOutput = 6;

            // Act
            int actualOutput = countInversions.BruteForceApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void helperMethodsArrayWithIncreasingAndDecreasingElements_ReturnsInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] input = new int[] { 5, 6, 3, 4 };
            int expectedOutput = 4;

            // Act
            int actualOutput = countInversions.BruteForceApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
