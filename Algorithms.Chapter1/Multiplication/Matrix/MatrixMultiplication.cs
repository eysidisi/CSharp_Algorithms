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

        //        Strassen(Very High-Level Description)
        //        Input: n ⇥ n integer matrices X and Y.
        //        Output: Z = X · Y.
        //        Assumption: n is a power of 2.
        //        if n = 1 then 
        //          return the 1 ⇥ 1 matrix with entry X[1][1] · Y[1][1]
        //        else // recursive case
        //          A, B, C, D := submatrices of X 
        //          E,F,G,H := submatrices of Y 
        //          recursively compute seven(cleverly chosen) products involving A,B, . . . ,H
        //          return the appropriate(cleverly chosen) additions 
        //          and subtractions of the matrices computed in the
        //          previous step

        //        P1 = A · (F −H)
        //        P2 = (A + B) ·H
        //        P3 = (C + D) · E
        //        P4 = D · (G− E)
        //        P5 = (A + D) · (E +H)
        //        P6 = (B − D) · (G+H)
        //        P7 = (A − C) · (E + F).
        public int[,] StrassenAlgorithm(int[,] matA, int[,] matB)
        {
            if (matA.Length == 1 && matB.Length == 1)
            {
                return new int[,] { { matA[0, 0] * matB[0, 0] } };
            }

            throw new NotImplementedException();
        }

    }
}
