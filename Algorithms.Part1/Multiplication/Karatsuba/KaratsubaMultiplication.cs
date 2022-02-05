
namespace Algorithms.Part1.Multiplication.Karatsuba
{
    public class KaratsubaMultiplication
    {
        HelperMethods helperMethods = new();

        // THIS METHOD COMPUTES MULTIPLICATION OF TWO NUMBERS USING THE ALGORITHM GIVEN BELOW

        //        if n = 1 then // base case
        //          compute x · y in one step and return the result
        //        else // recursive case
        //          a, b := first and second halves of x
        //          c, d := first and second halves of y
        //          compute p := a + b and q := c + d using grade-school addition
        //          recursively compute ac := a · c, bd := b · d, and pq := p · q
        //          compute adbc := pq − ac − bd using grade-school addition
        //          compute 10n · ac + 10n/2 · adbc + bd using grade-school addition and return the result

        public long Multiply(long num1, long num2)
        {
            bool isResultNegative = false;

            if (num1 < 0 && num2 > 0 ||
                num1 > 0 && num2 < 0)
            {
                isResultNegative = true;
            }

            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);

            int n1 = helperMethods.GetNumOfDigits(num1);
            int n2 = helperMethods.GetNumOfDigits(num2);

            if (n1 == 1 && n2 == 1)
            {
                return num1 * num2;
            }

            int n = Math.Min(n1, n2);
            int halfLength = (int)Math.Ceiling(n / 2.0);

            long a = helperMethods.FirstPartOfNum(num1, halfLength);
            long b = helperMethods.LastPartOfNum(num1, halfLength);
            long c = helperMethods.FirstPartOfNum(num2, halfLength);
            long d = helperMethods.LastPartOfNum(num2, halfLength);

            long p = a + b;
            long q = c + d;

            long ac = Multiply(a, c);
            long bd = Multiply(b, d);
            long pq = Multiply(p, q);

            long adbc = pq - ac - bd;


            long acZerosAdded = helperMethods.AddZeros(halfLength * 2, ac);
            long adbcZerosAdded = helperMethods.AddZeros(halfLength, adbc);

            long result = acZerosAdded + adbcZerosAdded + bd;

            if (isResultNegative)
            {
                return -result;
            }

            return result;
        }
    }
}
