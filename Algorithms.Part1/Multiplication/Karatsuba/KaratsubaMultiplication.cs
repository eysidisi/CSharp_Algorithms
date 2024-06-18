using System.Numerics;

namespace Algorithms.Part1.Multiplication.Karatsuba
{
    public class KaratsubaMultiplication
    {
        // THIS METHOD COMPUTES MULTIPLICATION OF TWO NUMBERS USING THE ALGORITHM GIVEN BELOW

        //        if n = 1 then // base case
        //          compute x · y in one step and return the result
        //        else // recursive case
        //          a, b := first and second halves of x
        //          c, d := first and second halves of y
        //          compute p := a + b and q := c + d using grade-school addition
        //          recursively compute ac := a · c, bd := b · d, and pq := p · q
        //          compute adbc := pq − ac − bd using grade-school addition
        //          compute 10^n · ac + 10^(n/2) · adbc + bd using grade-school addition
        //          and return the result

        public BigInteger Multiply(BigInteger num1, BigInteger num2)
        {
            bool isResultNegative = false;

            if (num1 < 0 && num2 > 0 ||
                num1 > 0 && num2 < 0)
            {
                isResultNegative = true;
            }

            num1 = BigInteger.Abs(num1);
            num2 = BigInteger.Abs(num2);

            int n1 = KaratsubaHelperMethods.GetNumOfDigits(num1);
            int n2 = KaratsubaHelperMethods.GetNumOfDigits(num2);

            if (n1 == 1 && n2 == 1)
            {
                return num1 * num2;
            }

            int n = Math.Min(n1, n2);
            int halfLength = (int)Math.Ceiling(n / 2.0);

            BigInteger a = KaratsubaHelperMethods.FirstPartOfNum(num1, halfLength);
            BigInteger b = KaratsubaHelperMethods.LastPartOfNum(num1, halfLength);
            BigInteger c = KaratsubaHelperMethods.FirstPartOfNum(num2, halfLength);
            BigInteger d = KaratsubaHelperMethods.LastPartOfNum(num2, halfLength);

            BigInteger p = a + b;
            BigInteger q = c + d;

            BigInteger ac = Multiply(a, c);
            BigInteger bd = Multiply(b, d);
            BigInteger pq = Multiply(p, q);

            BigInteger adbc = pq - ac - bd;

            BigInteger acZerosAdded = KaratsubaHelperMethods.AddZeros(halfLength * 2, ac);
            BigInteger adbcZerosAdded = KaratsubaHelperMethods.AddZeros(halfLength, adbc);

            BigInteger result = acZerosAdded + adbcZerosAdded + bd;

            if (isResultNegative)
            {
                return -result;
            }

            return result;
        }
    }
}
