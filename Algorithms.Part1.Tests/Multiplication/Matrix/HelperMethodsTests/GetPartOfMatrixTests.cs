using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Multiplication.Matrix;

namespace Algorithms.Part1.Tests.Multiplication.Matrix.HelperMethodsTests
{
    public class GetPartOfMatrixTests
    {
        [Fact]
        public void MatrixWithPowerOfTwoDimension()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            int[,] input = new int[,]
            {
                {1,   2, 3,   4},
                {5,   6, 7,   8},
                {9,  10, 11, 12},
                {13, 14, 15, 16}
            };

            int[,] expectedFirstPart = new int[,]
            {
                {1,2},
                {5,6}
            };

            int[,] expectedSecondPart = new int[,]
            {
                {3,4},
                {7,8}
            };

            int[,] expectedThirdPart = new int[,]
            {
                {9,10},
                {13,14}
            };

            int[,] expectedFourthPart = new int[,]
            {
                {11,12},
                {15,16}
            };

            // Act
            var actualFirstPart = helperMethods.FirstQuadrantOfMatrix(input);
            var actualSecondPart = helperMethods.SecondQuadrantOfMatrix(input);
            var actualThirdPart = helperMethods.ThirdQuadrantOfMatrix(input);
            var actualFourthPart = helperMethods.FourthQuadrantOfMatrix(input);

            // Assert

            Assert.Equal(expectedFirstPart, actualFirstPart);
            Assert.Equal(expectedSecondPart, actualSecondPart);
            Assert.Equal(expectedThirdPart, actualThirdPart);
            Assert.Equal(expectedFourthPart, actualFourthPart);
        }

        [Fact]
        public void MatrixNonPowerOfTwoDimension()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            int[,] input = new int[,]
            {
                {1, 2, 3,  4, 5, 6},
                {7, 8, 9, 10,11,12},
                {13,14,15,16,17,18},
                {19,20,21,22,23,24},
                {25,26,27,28,29,30},
                {31,32,33,34,35,36}
            };

            int[,] expectedFirstPart = new int[,]
            {
                {1,2,3},
                {7,8,9},
                {13,14,15}
            };

            int[,] expectedSecondPart = new int[,]
            {
                {4,5,6},
                {10,11,12},
                {16,17,18}
            };

            int[,] expectedThirdPart = new int[,]
            {
                {19,20,21},
                {25,26,27},
                {31,32,33}
            };

            int[,] expectedFourthPart = new int[,]
            {
                {22,23,24},
                {28,29,30},
                {34,35,36}
            };

            // Act
            var actualFirstPart = helperMethods.FirstQuadrantOfMatrix(input);
            var actualSecondPart = helperMethods.SecondQuadrantOfMatrix(input);
            var actualThirdPart = helperMethods.ThirdQuadrantOfMatrix(input);
            var actualFourthPart = helperMethods.FourthQuadrantOfMatrix(input);

            // Assert

            Assert.Equal(expectedFirstPart, actualFirstPart);
            Assert.Equal(expectedSecondPart, actualSecondPart);
            Assert.Equal(expectedThirdPart, actualThirdPart);
            Assert.Equal(expectedFourthPart, actualFourthPart);
        }

    }
}
