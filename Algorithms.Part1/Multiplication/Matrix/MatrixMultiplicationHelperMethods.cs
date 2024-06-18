using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Multiplication.Matrix
{
    public static class MatrixMultiplicationHelperMethods
    {
        public static int CalculateValueAtPosition(int rowIndex, int colIndex, int[,] matA, int[,] matB)
        {
            int numOfCols = matA.GetLength(1);

            int result = 0;

            for (int index = 0; index < numOfCols; index++)
            {
                result += matA[rowIndex, index] * matB[index, colIndex];
            }

            return result;
        }
        public static int[,] FirstQuadrantOfMatrix(int[,] matA)
        {
            int resultMatLength = matA.GetLength(0) / 2;

            int startingRowIndex = 0;
            int endingRowIndex = resultMatLength - 1;

            int startingColIndex = 0;
            int endingColIndex = resultMatLength - 1;

            var firstPartOfMatrix = GetPartOfMatrix(matA, startingRowIndex, endingRowIndex, startingColIndex, endingColIndex);

            return firstPartOfMatrix;
        }
        public static int[,] SecondQuadrantOfMatrix(int[,] matA)
        {
            int resultMatLength = matA.GetLength(0) / 2;

            int startingRowIndex = 0;
            int endingRowIndex = resultMatLength - 1;

            int startingColIndex = resultMatLength;
            int endingColIndex = matA.GetLength(0) - 1;

            var secondPartOfMatrix = GetPartOfMatrix(matA, startingRowIndex, endingRowIndex, startingColIndex, endingColIndex);

            return secondPartOfMatrix;

        }
        public static int[,] ThirdQuadrantOfMatrix(int[,] matA)
        {
            int resultMatLength = matA.GetLength(0) / 2;

            int startingRowIndex = resultMatLength;
            int endingRowIndex = matA.GetLength(0) - 1;

            int startingColIndex = 0;
            int endingColIndex = resultMatLength - 1;

            var thirdPartOfMatrix = GetPartOfMatrix(matA, startingRowIndex, endingRowIndex, startingColIndex, endingColIndex);

            return thirdPartOfMatrix;
        }
        public static int[,] FourthQuadrantOfMatrix(int[,] matA)
        {
            int resultMatLength = matA.GetLength(0) / 2;

            int startingRowIndex = resultMatLength;
            int endingRowIndex = matA.GetLength(0) - 1;

            int startingColIndex = resultMatLength;
            int endingColIndex = matA.GetLength(0) - 1;

            var fourthPartOfMatrix = GetPartOfMatrix(matA, startingRowIndex, endingRowIndex, startingColIndex, endingColIndex);

            return fourthPartOfMatrix;
        }
        public static int[,] SubtractMatrices(int[,] matA, int[,] matB)
        {
            int[,] resultMatrix = new int[matA.GetLength(0), matA.GetLength(1)];

            for (int rowIndex = 0; rowIndex < matA.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matA.GetLength(1); colIndex++)
                {
                    resultMatrix[rowIndex, colIndex] = matA[rowIndex, colIndex] - matB[rowIndex, colIndex];
                }
            }

            return resultMatrix;
        }
        public static int[,] SumMatrices(int[,] matA, int[,] matB)
        {
            int[,] resultMatrix = new int[matA.GetLength(0), matA.GetLength(1)];

            for (int rowIndex = 0; rowIndex < matA.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matA.GetLength(1); colIndex++)
                {
                    resultMatrix[rowIndex, colIndex] = matA[rowIndex, colIndex] + matB[rowIndex, colIndex];
                }
            }

            return resultMatrix;
        }
        private static int[,] GetPartOfMatrix(int[,] matA, int startingRowIndex, int endingRowIndex, int startingColIndex, int endingColIndex)
        {
            int[,] firstPart = new int[endingRowIndex - startingRowIndex + 1, endingColIndex - startingColIndex + 1];

            int firstPartRowIndex = 0;

            for (int rowIndex = startingRowIndex; rowIndex <= endingRowIndex; rowIndex++)
            {
                int firstPartColIndex = 0;
                for (int colIndex = startingColIndex; colIndex <= endingColIndex; colIndex++)
                {
                    firstPart[firstPartRowIndex, firstPartColIndex] = matA[rowIndex, colIndex];
                    firstPartColIndex++;
                }
                firstPartRowIndex++;
            }

            return firstPart;
        }
        public static int[,] FormResultantMatrix(int[,] firstQuadrant, int[,] secondQuadrant, int[,] thirdQuadrant, int[,] fourthQuadrant)
        {
            int numOfRows = firstQuadrant.GetLength(0) + thirdQuadrant.GetLength(0);
            int numOfCols = firstQuadrant.GetLength(1) + secondQuadrant.GetLength(1);

            int[,] resultantMatrix = new int[numOfRows, numOfCols];

            resultantMatrix = FillFirstQuadrant(resultantMatrix, firstQuadrant);
            resultantMatrix = FillSecondQuadrant(resultantMatrix, secondQuadrant);
            resultantMatrix = FillThirdQuadrant(resultantMatrix, thirdQuadrant);
            resultantMatrix = FillFourthQuadrant(resultantMatrix, fourthQuadrant);

            return resultantMatrix;
        }
        private static int[,] FillFirstQuadrant(int[,] inputMatrix, int[,] firstQuadrant)
        {
            int startingRowIndex = 0;
            int endingRowIndex = inputMatrix.GetLength(0) / 2;

            int startingColIndex = 0;
            int endingColIndex = inputMatrix.GetLength(1) / 2;

            int firstQuadrantRowIndex = 0;
            for (int rowIndex = startingRowIndex; rowIndex < endingRowIndex; rowIndex++)
            {
                int firstQuadrantColIndex = 0;
                for (int colIndex = startingColIndex; colIndex < endingColIndex; colIndex++)
                {
                    inputMatrix[rowIndex, colIndex] = firstQuadrant[firstQuadrantRowIndex, firstQuadrantColIndex];
                    firstQuadrantColIndex++;
                }
                firstQuadrantRowIndex++;
            }

            return inputMatrix;
        }
        private static int[,] FillSecondQuadrant(int[,] inputMatrix, int[,] secondQuadrant)
        {
            int startingRowIndex = 0;
            int endingRowIndex = inputMatrix.GetLength(0) / 2;

            int startingColIndex = inputMatrix.GetLength(1) / 2;
            int endingColIndex = inputMatrix.GetLength(1);

            int secondQuadrantRowIndex = 0;
            for (int rowIndex = startingRowIndex; rowIndex < endingRowIndex; rowIndex++)
            {
                int secondQuadrantColIndex = 0;
                for (int colIndex = startingColIndex; colIndex < endingColIndex; colIndex++)
                {
                    inputMatrix[rowIndex, colIndex] = secondQuadrant[secondQuadrantRowIndex, secondQuadrantColIndex];
                    secondQuadrantColIndex++;
                }
                secondQuadrantRowIndex++;
            }

            return inputMatrix;
        }
        private static int[,] FillThirdQuadrant(int[,] inputMatrix, int[,] thirdQuadrant)
        {
            int startingRowIndex = inputMatrix.GetLength(0) / 2;
            int endingRowIndex = inputMatrix.GetLength(0);

            int startingColIndex = 0;
            int endingColIndex = inputMatrix.GetLength(1) / 2;

            int thirdQuadrantRowIndex = 0;
            for (int rowIndex = startingRowIndex; rowIndex < endingRowIndex; rowIndex++)
            {
                int thirdQuadrantColIndex = 0;
                for (int colIndex = startingColIndex; colIndex < endingColIndex; colIndex++)
                {
                    inputMatrix[rowIndex, colIndex] = thirdQuadrant[thirdQuadrantRowIndex, thirdQuadrantColIndex];
                    thirdQuadrantColIndex++;
                }
                thirdQuadrantRowIndex++;
            }

            return inputMatrix;
        }
        private static int[,] FillFourthQuadrant(int[,] inputMatrix, int[,] fourthQuadrant)
        {
            int startingRowIndex = inputMatrix.GetLength(0) / 2;
            int endingRowIndex = inputMatrix.GetLength(0);

            int startingColIndex = inputMatrix.GetLength(1) / 2;
            int endingColIndex = inputMatrix.GetLength(1);

            int fourthQuadrantRowIndex = 0;

            for (int rowIndex = startingRowIndex; rowIndex < endingRowIndex; rowIndex++)
            {
                int fourthQuadrantColIndex = 0;
                for (int colIndex = startingColIndex; colIndex < endingColIndex; colIndex++)
                {
                    inputMatrix[rowIndex, colIndex] = fourthQuadrant[fourthQuadrantRowIndex, fourthQuadrantColIndex];
                    fourthQuadrantColIndex++;
                }
                fourthQuadrantRowIndex++;
            }

            return inputMatrix;
        }
    }
}
