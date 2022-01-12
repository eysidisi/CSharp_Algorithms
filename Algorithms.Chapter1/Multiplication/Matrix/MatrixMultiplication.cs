using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter1.Multiplication.Matrix
{
    public class MatrixMultiplication
    {
        HelperMethods helperMethods = new HelperMethods();
        public int[,] BruteForce(int[,] matA, int[,] matB)
        {
            int numOfRows = matA.GetLength(0);
            int numOfCols = matB.GetLength(1);

            int[,] result = new int[matA.GetLength(0), matB.GetLength(1)];

            for (int rowIndex = 0; rowIndex < numOfRows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < numOfCols; colIndex++)
                {
                    result[rowIndex, colIndex] = helperMethods.CalculateValueAtPosition(rowIndex, colIndex, matA, matB);
                }
            }

            return result;
        }
    }
}
