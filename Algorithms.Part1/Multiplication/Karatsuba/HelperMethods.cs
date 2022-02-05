using System.Text;

namespace Algorithms.Part1.Multiplication.Karatsuba
{
    public class HelperMethods
    {
        public long FirstPartOfNum(long num, int lastPartLength)
        {
            int length = GetNumOfDigits(num);

            string numberInStr = num.ToString();

            StringBuilder firstPartOfNum = new();

            for (int strIndex = 0; strIndex < length - lastPartLength; strIndex++)
            {
                firstPartOfNum.Append(numberInStr[strIndex]);
            }

            // Number has just one digit so has no first part
            if (firstPartOfNum.Length == 0)
            {
                return 0;
            }

            return long.Parse(firstPartOfNum.ToString());
        }

        public long LastPartOfNum(long num, int lastPartLength)
        {
            int length = GetNumOfDigits(num);

            string numberInStr = num.ToString();

            StringBuilder lastPartOfNum = new();

            for (int strIndex = length - lastPartLength; strIndex < length; strIndex++)
            {
                lastPartOfNum.Append(numberInStr[strIndex]);
            }

            return long.Parse(lastPartOfNum.ToString());
        }

        public int GetNumOfDigits(long num1)
        {
            num1 = Math.Abs(num1);

            int numOfDigits = 1;

            while (num1 >= 10)
            {
                num1 /= 10;
                numOfDigits++;
            }

            return numOfDigits;
        }

        public long AddZeros(int numberOfZerosToAdd, long inputNumber)
        {
            string zeros = new(Enumerable.Repeat('0', numberOfZerosToAdd).ToArray());

            string numberWithZeros = inputNumber.ToString() + zeros;

            return long.Parse(numberWithZeros);
        }
    }
}
