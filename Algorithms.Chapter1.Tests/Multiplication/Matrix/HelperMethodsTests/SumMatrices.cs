using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Chapter1.Multiplication.Matrix;

namespace Algorithms.Chapter1.Tests.Multiplication.Matrix.HelperMethodsTests
{
    public class SumMatrices
    {
        [Fact]
        public void OneElement()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

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
                { 8}
            };

            // Act
            var actualResult = helperMethods.SumMatrices(mat1, mat2);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }
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

            var expectedResult = new int[,]
            {
                { 2, 4, 6 },
                { 8, 10, 12 },
                { 14, 16, 18 }
            };

            // Act
            var actualResult = helperMethods.SumMatrices(mat1, mat2);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void NotSquareMatrices()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

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
                { 2, 4, 6,8 },
                { 8, 10, 12,10 },
                { 14, 16, 18,12 }
            };

            // Act
            var actualResult = helperMethods.SumMatrices(mat1, mat2);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }
    }
}
