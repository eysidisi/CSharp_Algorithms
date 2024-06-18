using Xunit;
using Algorithms.Part1.Multiplication.Matrix;

namespace Algorithms.Part1.Tests.Multiplication.Matrix.HelperMethodTests
{
    public class CalculateValueAtPositionTests
    {
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

            //  Multiplication Result
            //  30  36  42
            //  66  81  96
            //  102 126 150

            int rowIndex = 1;
            int colIndex = 2;
            int expectedOutput = 96;

            // Act
            int actualOutput = MatrixMultiplicationHelperMethods.CalculateValueAtPosition(rowIndex, colIndex, mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void MatricesWithDifferentDimension()
        {
            // Arrange


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
            int actualOutput = MatrixMultiplicationHelperMethods.CalculateValueAtPosition(rowIndex, colIndex, mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
