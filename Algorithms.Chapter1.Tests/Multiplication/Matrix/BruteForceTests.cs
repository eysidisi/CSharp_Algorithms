using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Multiplication.Matrix;

namespace Algorithms.Part1.Tests.Multiplication.Matrix
{
    public class BruteForceTests
    {
        [Fact]
        public void SquareMatrices()
        {
            // Arrange
            MatrixMultiplication matrixMultiplication = new MatrixMultiplication();

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

            var expectedOutput = new int[,]
            {
                { 30 ,36 ,42 },
                { 66 ,81 ,96 },
                { 102,126,150 }
            };

            // Act
            var actualOutput = matrixMultiplication.BruteForce(mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void MatricesWithDifferentDimension()
        {
            // Arrange
            MatrixMultiplication matrixMultiplication = new MatrixMultiplication();

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

            var expectedOutput = new int[,]
            {
                { 22 , 28 },
                { 49 , 64 }
            };

            // Act
            var actualOutput = matrixMultiplication.BruteForce(mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
