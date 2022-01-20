﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Part1.Count;
using Algorithms.Part1.FileIO;
using Xunit;

namespace Algorithms.Part1.Tests.Count.CountInversionsTests
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
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

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
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

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
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

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
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

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
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

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
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

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
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

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
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

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
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

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
            var actualOutput = countInversions.DivideAndConquerApproach(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ReadFromFile_SomeNumOfInversions()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            FileManager fileManager = new FileManager();
            string filePath = Directory.GetCurrentDirectory() + @"\Count\CountInversionsTests\TextFiles\FourElements.txt";
            var inputArr = fileManager.ReadFileIntoIntArray(filePath);
            int expectedOutput = 3;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(inputArr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void ReadFromFile_CourseraAssignment()
        {
            // Arrange
            CountInversions countInversions = new CountInversions();
            FileManager fileManager = new FileManager();
            string filePath = Directory.GetCurrentDirectory() + @"\Count\CountInversionsTests\TextFiles\CourseraAssignment.txt";
            var inputArr = fileManager.ReadFileIntoIntArray(filePath);
            var expectedOutput = 2407905288;

            // Act
            var actualOutput = countInversions.DivideAndConquerApproach(inputArr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
