using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter1.Multiplication.Matrix
{
    public class HelperMethods
    {
        public int CalculateValueAtPosition(int rowIndex, int colIndex, int[,] matA, int[,] matB)
        {
            int numOfCols = matA.GetLength(1);

            int result = 0;

            for (int index = 0; index < numOfCols; index++)
            {
                result += matA[rowIndex, index] * matB[index, colIndex];
            }

            return result;
        }
    }
}
