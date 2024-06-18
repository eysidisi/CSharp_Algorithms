using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Sort.MergeSortAlgorithm
{
    public static class MergeSortHelperMethods
    {
        public static int[] GetArrFirstPart(int[] unsortedArr)
        {
            int halfLength = unsortedArr.Length / 2;

            List<int> firstPart = new();

            for (int i = 0; i < halfLength; i++)
            {
                firstPart.Add(unsortedArr[i]);
            }

            return firstPart.ToArray();
        }

        public static int[] GetSecondPart(int[] unsortedArr)
        {
            int halfLength = unsortedArr.Length / 2;

            List<int> secondPart = new();

            for (int i = halfLength; i < unsortedArr.Length; i++)
            {
                secondPart.Add(unsortedArr[i]);
            }

            return secondPart.ToArray();
        }

        public static int[] MergeSortedArrays(int[] firstArr, int[] secondArr)
        {
            int[] sortedArray = new int[firstArr.Length + secondArr.Length];
            int firstPartIndex = 0, secondPartIndex = 0;

            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (firstPartIndex < firstArr.Length &&
                    (secondPartIndex >= secondArr.Length || firstArr[firstPartIndex] <= secondArr[secondPartIndex]))
                {
                    sortedArray[i] = firstArr[firstPartIndex];
                    firstPartIndex++;
                }
                else
                {
                    sortedArray[i] = secondArr[secondPartIndex];
                    secondPartIndex++;
                }
            }

            return sortedArray;
        }
    }
}
