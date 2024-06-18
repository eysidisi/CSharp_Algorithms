using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Multiplication.Matrix;

namespace Algorithms.Part1.Tests.Multiplication.Matrix.HelperMethodsTests
{
    public class FormResultMatrix
    {
        [Fact]
        public void OneDimensinalMatrices()
        {
            // Arrange
            var firstQuadrant = new int[,]
            {
                { 1 }
            };

            var secondQuadrant = new int[,]
            {
                { 2 }
            };

            var thirdQuadrant = new int[,]
            {
                { 3 }
            };

            var fourthQuadrant = new int[,]
            {
                { 4 }
            };

            var expectedOutput = new[,]
            {
                {1,2 },
                {3,4 }
            };

            // Act
            var actualOutput = MatrixMultiplicationHelperMethods.FormResultantMatrix(firstQuadrant, secondQuadrant, thirdQuadrant, fourthQuadrant);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void TwoDimensinalMatrices()
        {
            // Arrange

            // 1,2,3,4
            // 5,6,7,8
            // 9, 10, 11, 12
            // 13, 14, 15, 16

            var firstQuadrant = new int[,]
            {
                { 1,2 },
                { 5,6 }
            };

            var secondQuadrant = new int[,]
            {
                { 3,4 },
                { 7,8 },
            };

            var thirdQuadrant = new int[,]
            {
                { 9,10 },
                { 13,14 }
            };

            var fourthQuadrant = new int[,]
            {
                { 11,12 },
                { 15,16 }
            };

            var expectedOutput = new[,]
            {
                {1,   2, 3,   4},
                {5,   6, 7,   8},
                {9,  10, 11, 12},
                {13, 14, 15, 16},
            };

            // Act
            var actualOutput = MatrixMultiplicationHelperMethods.FormResultantMatrix(firstQuadrant, secondQuadrant, thirdQuadrant, fourthQuadrant);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
