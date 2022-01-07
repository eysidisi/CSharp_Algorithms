using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter1
{
    public class KaratsubaMultiplication
    {
        public long Multiply(long num1, long num2)
        {
            if (num1 < 10 && num2 < 10)
            {
                return num1 * num2;
            }

            int numLen = FindNumOfDigits(num1);
            long num1LastPart = FindLastPart(num1, numLen);
            long num1FirstPart = FindFirstPart(num1, numLen);

        }

        private long FindLastPart(long num1, int numLen)
        {
            throw new NotImplementedException();
        }

        private int FindNumOfDigits(long num1)
        {
            int numOfDigits = 1;

            while (num1 >= 10)
            {
                num1 /= 10;
                numOfDigits++;
            }

            return numOfDigits;
        }
    }
}
