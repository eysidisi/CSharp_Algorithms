using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Part1.Multiplication.Matrix;
using Xunit;

namespace Algorithms.Part1.Tests.Multiplication.Matrix.HelperMethodsTests
{
    public class SubtractMatrices
    {
        [Fact]
        public void OneElement()
        {
            // Arrange
            var mat1 = new int[,]
            {
                { 1}
            };

            var mat2 = new int[,]
            {
                { 7}
            };

            var expectedResult = new int[,]
            {
                { -6}
            };

            // Act
            var actualResult = MatrixMultiplicationHelperMethods.SubtractMatrices(mat1, mat2);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }
        [Fact]
        public void SquareMatrices()
        {
            // Arrange

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

            var expectedResult = new int[,]
            {
                { 0,0,0   },
                { 0,0,0   },
                { 0,0,0   }
            };

            // Act
            var actualResult = MatrixMultiplicationHelperMethods.SubtractMatrices(mat1, mat2);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void NotSquareMatrices()
        {
            // Arrange
            var mat1 = new int[,]
            {
                { 1, 2, 3,4 },
                { 4, 5, 6,5 },
                { 7, 8, 9,6 }
            };

            var mat2 = new int[,]
            {
                { 1, 2, 3,4 },
                { 4, 5, 6,5 },
                { 7, 8, 9,6 }
            };

            var expectedResult = new int[,]
            {
                { 0,0,0,0 },
                { 0,0,0,0 },
                { 0,0,0,0 }
            };

            // Act
            var actualResult = MatrixMultiplicationHelperMethods.SubtractMatrices(mat1, mat2);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }
    }
}
