using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter1.Count
{
    public class HelperMethods
    {
        public int MergeAndCountNumberOfInversions(int[] firstPartOfTheArr, int[] secondPartOfTheArr, ref int[] arr)
        {
            int firstPartIndex = 0;
            int secondPartIndex = 0;
            int mergedArrIndex = 0;
            int numOfInversions = 0;

            while (mergedArrIndex < arr.Length)
            {
                if (firstPartIndex >= firstPartOfTheArr.Length)
                {
                    arr[mergedArrIndex] = secondPartOfTheArr[secondPartIndex];
                    secondPartIndex++;
                }

                else if (secondPartIndex >= secondPartOfTheArr.Length)
                {
                    arr[mergedArrIndex] = firstPartOfTheArr[firstPartIndex];
                    firstPartIndex++;
                }

                else
                {
                    if (secondPartOfTheArr[secondPartIndex] >= firstPartOfTheArr[firstPartIndex])
                    {
                        arr[mergedArrIndex] = firstPartOfTheArr[firstPartIndex];
                        firstPartIndex++;
                    }
                    else
                    {
                        arr[mergedArrIndex] = secondPartOfTheArr[secondPartIndex];
                        secondPartIndex++;
                        numOfInversions += firstPartOfTheArr.Length - firstPartIndex;
                    }
                }

                mergedArrIndex++;
            }

            return numOfInversions;
        }
    }
}
