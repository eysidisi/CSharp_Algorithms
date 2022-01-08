using System.Text;

namespace Algorithms.Chapter1.Multiplication
{
    public class HelperMethods
    {
        public long FirstPartOfNum(long num, int lastPartLength)
        {
            int length = GetNumOfDigits(num);

            string numberInStr = num.ToString();

            StringBuilder strFirstPartOfNum = new();

            for (int strIndex = 0; strIndex < length - lastPartLength; strIndex++)
            {
                strFirstPartOfNum.Append(numberInStr[strIndex]);
            }

            // If number has  just one digit
            if (strFirstPartOfNum.Length == 0)
            {
                return 0;
            }

            var firstPart = long.Parse(strFirstPartOfNum.ToString());
            return firstPart;
        }

        public long LastPartOfNum(long num, int lastPartLength)
        {
            int length = GetNumOfDigits(num);

            string numberInStr = num.ToString();

            StringBuilder strFirstPartOfNum = new();

            for (int strIndex = length - lastPartLength; strIndex < length; strIndex++)
            {
                strFirstPartOfNum.Append(numberInStr[strIndex]);
            }

            var firstPart = long.Parse(strFirstPartOfNum.ToString());
            return firstPart;
        }

        public int GetNumOfDigits(long num1)
        {
            int numOfDigits = 1;
            num1 = Math.Abs(num1);

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
