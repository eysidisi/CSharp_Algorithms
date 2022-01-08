using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter1.Sort
{
    public class HelperMethods
    {
        public int[] FirstPart(int[] unsortedArr)
        {
            int halfLength = unsortedArr.Length / 2;

            List<int> firstPart = new();

            for (int i = 0; i < halfLength; i++)
            {
                firstPart.Add(unsortedArr[i]);
            }

            return firstPart.ToArray();
        }
        public int[] SecondPart(int[] unsortedArr)
        {
            int halfLength = unsortedArr.Length / 2;

            List<int> secondPart = new();

            for (int i = halfLength; i < unsortedArr.Length; i++)
            {
                secondPart.Add(unsortedArr[i]);
            }

            return secondPart.ToArray();
        }


        int firstArrIndex = 0;
        int secondArrIndex = 0;
        int mergedArrIndex = 0;

        public int[] MergeSortedArrays(int[] arrFirst, int[] arrSecond)
        {
            int[] mergedArr = new int[arrFirst.Length + arrSecond.Length];

            MergeArraysUntilOneIsExhausted(arrFirst, arrSecond, mergedArr);

            MergeRemainingArrays(arrFirst, arrSecond, mergedArr);

            return mergedArr;
        }
        private void MergeArraysUntilOneIsExhausted(int[] arrFirst, int[] arrSecond, int[] mergedArr)
        {
            while (firstArrIndex < arrFirst.Length && secondArrIndex < arrSecond.Length)
            {
                if (arrFirst[firstArrIndex] < arrSecond[secondArrIndex])
                {
                    mergedArr[mergedArrIndex] = arrFirst[firstArrIndex];
                    firstArrIndex++;
                }

                else
                {
                    mergedArr[mergedArrIndex] = arrSecond[secondArrIndex];
                    secondArrIndex++;
                }

                mergedArrIndex++;
            }
        }
        private void MergeRemainingArrays(int[] arrFirst, int[] arrSecond, int[] mergedArr)
        {
            while (firstArrIndex != arrFirst.Length)
            {
                mergedArr[mergedArrIndex] = arrFirst[firstArrIndex];
                mergedArrIndex++;
                firstArrIndex++;
            }

            while (secondArrIndex != arrSecond.Length)
            {
                mergedArr[mergedArrIndex] = arrSecond[secondArrIndex];
                mergedArrIndex++;
                secondArrIndex++;
            }
        }
    }
}
