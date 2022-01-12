using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Chapter1.Count;
using Xunit;

namespace Algorithms.Chapter1.Tests.Count.CountInversionsTests
{
    public class DivideAndConquerApproachTests
    {
        [Fact]
        public void ArrayWithNoElement()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] arr = new int[0];
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.DivideAndConquerApproach(ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ArrayWithOneElement()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] arr = new int[1] { 10 };
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.DivideAndConquerApproach(ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);

        }

        [Fact]
        public void ArrayWithTwoElements_NoInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] arr = new int[2] { 1, 2 };
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.DivideAndConquerApproach(ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);

        }

        [Fact]
        public void ArrayWithTwoElements_MaxNumOfInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] arr = new int[2] { 2, 1 };
            int expectedOutput = 1;

            // Act
            int actualOutput = countInversions.DivideAndConquerApproach(ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ArrayWithOddNumberOfElements_NoInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] arr = new int[] { 1, 2, 2, 4, 5 };
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.DivideAndConquerApproach(ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ArrayWithOddNumberOfElements_MaxNumOfInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] arr = new int[] { 5, 4, 3, 2, 1 };
            int expectedOutput = 10;

            // Act
            int actualOutput = countInversions.DivideAndConquerApproach(ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ArrayWithOddNumberOfElements_SomeNumOfInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] arr = new int[] { 1, 5, 5, 3, 4 };
            int expectedOutput = 4;

            // Act
            int actualOutput = countInversions.DivideAndConquerApproach(ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ArrayWithEvenNumberOfElements_NoInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] arr = new int[] { 1, 2, 2, 4 };
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.DivideAndConquerApproach(ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ArrayWithEvenNumberOfElements_MaxNumOfInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] arr = new int[] { 4, 3, 2, 1 };
            int expectedOutput = 6;

            // Act
            int actualOutput = countInversions.DivideAndConquerApproach(ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ArrayWithEvenNumberOfElements_SomeNumOfInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            int[] arr = new int[] { 5, 5, 7, 3 };
            int expectedOutput = 3;

            // Act
            int actualOutput = countInversions.DivideAndConquerApproach(ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
