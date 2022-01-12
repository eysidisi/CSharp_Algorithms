﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Chapter1.Multiplication.Matrix;

namespace Algorithms.Chapter1.Tests.Multiplication.Matrix
{
    public class HelperMethodsTests
    {
        [Fact]
        public void SquareMatrices()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            var mat1 = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            var mat2 = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            //  Multiplication Result
            //  30  36  42
            //  66  81  96
            //  102 126 150

            int rowIndex = 1;
            int colIndex = 2;
            int expectedOutput = 96;

            // Act
            int actualOutput = helperMethods.CalculateValueAtPosition(rowIndex, colIndex, mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void MatricesWithDifferentDimension()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            var mat1 = new int[,]
            {
                { 1, 2, 3},
                { 4, 5, 6 }
            };

            var mat2 = new int[,]
            {
                { 1, 2},
                { 3, 4},
                { 5, 6 }
            };

            //  Multiplication Result
            //  22  28
            //  49  64

            int rowIndex = 0;
            int colIndex = 1;
            int expectedOutput = 28;

            // Act
            int actualOutput = helperMethods.CalculateValueAtPosition(rowIndex, colIndex, mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
