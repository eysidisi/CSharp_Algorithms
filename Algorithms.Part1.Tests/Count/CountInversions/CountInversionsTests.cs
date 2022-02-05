using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Count;
using System.IO;
using Algorithms.Part1.FileIO;

namespace Algorithms.Part1.Tests.Count.CountInversions
{
    public class CountInversionsTests
    {
        [Fact]
        public void BruteForce_ArrayWithNoElement_ReturnsZero()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] input = new int[0];
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.BruteForceApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void BruteForce_ArrayWithOneElement_ReturnsZero()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] input = new int[1];
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.BruteForceApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void BruteForce_ArrayWithIncreasingElements_ReturnsZero()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] input = new int[] { 1, 2, 3, 4 };
            int expectedOutput = 0;

            // Act
            int actualOutput = countInversions.BruteForceApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void BruteForce_ArrayWithDecreasingElements_ReturnsInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] input = new int[] { 4, 3, 2, 1 };
            int expectedOutput = 6;

            // Act
            int actualOutput = countInversions.BruteForceApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void BruteForce_ArrayWithIncreasingAndDecreasingElements_ReturnsInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] input = new int[] { 5, 6, 3, 4 };
            int expectedOutput = 4;

            // Act
            int actualOutput = countInversions.BruteForceApproach(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void DivideAndConquerApproach_ArrayWithNoElement()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] arr = new int[0];
            int expectedOutput = 0;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DivideAndConquerApproach_ArrayWithOneElement()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] arr = new int[1] { 10 };
            int expectedOutput = 0;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);

        }

        [Fact]
        public void DivideAndConquerApproach_ArrayWithTwoElements_NoInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] arr = new int[2] { 1, 2 };
            int expectedOutput = 0;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);

        }

        [Fact]
        public void DivideAndConquerApproach_ArrayWithTwoElements_MaxNumOfInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] arr = new int[2] { 2, 1 };
            int expectedOutput = 1;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DivideAndConquerApproach_ArrayWithOddNumberOfElements_NoInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] arr = new int[] { 1, 2, 2, 4, 5 };
            int expectedOutput = 0;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DivideAndConquerApproach_ArrayWithOddNumberOfElements_MaxNumOfInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] arr = new int[] { 5, 4, 3, 2, 1 };
            int expectedOutput = 10;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DivideAndConquerApproach_ArrayWithOddNumberOfElements_SomeNumOfInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] arr = new int[] { 1, 5, 5, 3, 4 };
            int expectedOutput = 4;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DivideAndConquerApproach_ArrayWithEvenNumberOfElements_NoInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] arr = new int[] { 1, 2, 2, 4 };
            int expectedOutput = 0;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DivideAndConquerApproach_ArrayWithEvenNumberOfElements_MaxNumOfInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] arr = new int[] { 4, 3, 2, 1 };
            int expectedOutput = 6;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DivideAndConquerApproach_ArrayWithEvenNumberOfElements_SomeNumOfInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            int[] arr = new int[] { 5, 5, 7, 3 };
            int expectedOutput = 3;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DivideAndConquerApproach_ReadFromFile_SomeNumOfInversions()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            FileManager fileManager = new FileManager();
            string filePath = Directory.GetCurrentDirectory() + @"\Count\CountInversions\TestFiles\FourElements.txt";
            var inputArr = fileManager.ReadFileIntoIntArray(filePath);
            int expectedOutput = 3;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(inputArr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DivideAndConquerApproach_ReadFromFile_CourseraAssignment()
        {
            // Arrange
            var countInversions= new Part1.Count.CountInversions();
            FileManager fileManager = new FileManager();
            string filePath = Directory.GetCurrentDirectory() + @"\Count\CountInversions\TestFiles\CourseraAssignment.txt";
            var inputArr = fileManager.ReadFileIntoIntArray(filePath);
            var expectedOutput = 2407905288;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(inputArr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
