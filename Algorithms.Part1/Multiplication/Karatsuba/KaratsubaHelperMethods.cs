using System.Numerics;
using System.Text;

namespace Algorithms.Part1.Multiplication.Karatsuba
{
    public static class KaratsubaHelperMethods
    {
        public static BigInteger FirstPartOfNum(BigInteger num, int firstPartLength)
        {
            int length = GetNumOfDigits(num);

            string numberInStr = num.ToString();

            StringBuilder firstPartOfNum = new();

            for (int strIndex = 0; strIndex < length - firstPartLength; strIndex++)
            {
                firstPartOfNum.Append(numberInStr[strIndex]);
            }

            // Number has just one digit so has no first part
            if (firstPartOfNum.Length == 0)
            {
                return 0;
            }

            return BigInteger.Parse(firstPartOfNum.ToString());
        }

        public static BigInteger LastPartOfNum(BigInteger num, int lastPartLength)
        {
            int length = GetNumOfDigits(num);

            string numberInStr = num.ToString();

            StringBuilder lastPartOfNum = new();

            for (int strIndex = length - lastPartLength; strIndex < length; strIndex++)
            {
                lastPartOfNum.Append(numberInStr[strIndex]);
            }

            return BigInteger.Parse(lastPartOfNum.ToString());
        }

        public static int GetNumOfDigits(BigInteger num1)
        {
            num1 = BigInteger.Abs(num1);

            int numOfDigits = 1;

            while (num1 >= 10)
            {
                num1 /= 10;
                numOfDigits++;
            }

            return numOfDigits;
        }

        public static BigInteger AddZeros(int numberOfZerosToAdd, BigInteger inputNumber)
        {
            string zeros = new(Enumerable.Repeat('0', numberOfZerosToAdd).ToArray());

            string numberWithZeros = inputNumber.ToString() + zeros;

            return BigInteger.Parse(numberWithZeros);
        }
    }
}
