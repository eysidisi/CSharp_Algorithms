using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter1.Count
{
    public class CountInversions
    {
        public int NativeApproach(int[] arr)
        {
            int numOfInversions = 0;

            for (int firstIndex = 0; firstIndex < arr.Length - 1; firstIndex++)
            {
                for (int secondIndex = firstIndex + 1; secondIndex < arr.Length; secondIndex++)
                {
                    if (arr[firstIndex] > arr[secondIndex])
                    {
                        numOfInversions++;
                    }
                }
            }

            return numOfInversions;
        }

        public int DivideAndConquerApproach(int[] arr)
        {
            throw new NotImplementedException();
        }
    }
}
