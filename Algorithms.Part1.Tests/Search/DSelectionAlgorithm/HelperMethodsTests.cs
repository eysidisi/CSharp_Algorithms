using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Search.DSelectionAlgorithm;

namespace Algorithms.Part1.Tests.Search.DSelectionAlgorithm
{
    public class HelperMethodsTests
    {
        [Fact]
        public void GroupArraysIntoFive_OneElementArr()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            int[] arr = new int[1];
            List<int[]> expectedOutput = new List<int[]>() { new int[1] };

            // Act
            var actualOutput = helperMethods.GroupArraysIntoFive(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GroupArraysIntoFive_FourElementArr()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            int[] arr = new int[4] { 1, 2, 3, 4 };
            List<int[]> expectedOutput = new List<int[]>() { new int[4] { 1, 2, 3, 4 } };

            // Act
            var actualOutput = helperMethods.GroupArraysIntoFive(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GroupArraysIntoFive_FiveElementArr()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            List<int[]> expectedOutput = new List<int[]>() { new int[5] { 1, 2, 3, 4, 5 } };

            // Act
            var actualOutput = helperMethods.GroupArraysIntoFive(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);

        }

        [Fact]
        public void GroupArraysIntoFive_SixElementArr()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            int[] arr = new int[6] { 1, 2, 3, 4, 5, 6 };
            List<int[]> expectedOutput = new List<int[]>()
            {
                new int[5] { 1, 2, 3, 4, 5 },
                new int[1] { 6}
            };

            // Act
            var actualOutput = helperMethods.GroupArraysIntoFive(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void GroupArraysIntoFive_TenElementArr()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            int[] arr = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int[]> expectedOutput = new List<int[]>()
            {
                new int[5] { 1, 2, 3, 4, 5 },
                new int[5] { 6,7,8,9,10}
            };

            // Act
            var actualOutput = helperMethods.GroupArraysIntoFive(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GroupArraysIntoFive_ElevenElementArr()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            int[] arr = new int[11] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            List<int[]> expectedOutput = new List<int[]>()
            {
                new int[5] { 1, 2, 3, 4, 5 },
                new int[5] { 6,7,8,9,10},
                new int[1] { 11}
            };

            // Act
            var actualOutput = helperMethods.GroupArraysIntoFive(arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FindMedians_OneElementArr()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            List<int[]> input = new List<int[]>()
            {
                new int[] {5,4,1,2,3},
                new int[] { 1}
            };
            var expectedOutput = new int[] { 3, 1 };

            // Act
            var actualOutput = helperMethods.FindMedians(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void FindMedians_ThreeElementArr()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            List<int[]> input = new List<int[]>()
            {
                new int[] {5,4,1,2,3},
                new int[] {9,4,2}
            };
            var expectedOutput = new int[] { 3, 4 };

            // Act
            var actualOutput = helperMethods.FindMedians(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FindMedians_FourElementArr()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            List<int[]> input = new List<int[]>()
            {
                new int[] {5,4,1,2,3},
                new int[] {9,4,2,5}
            };
            var expectedOutput = new int[] { 3, 4 };

            // Act
            var actualOutput = helperMethods.FindMedians(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
