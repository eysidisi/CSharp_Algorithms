using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Part1.FileIO;
using Algorithms.Part1.Sort;
using Algorithms.Part1.Sort.MergeSortAlgorithm;
namespace Algorithms.Part1.Count
{
    public class CountInversions
    {
        public int BruteForceApproach(int[] arr)
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

        public long DivideAndConquerApproach(int[] arr)
        {
            int arrLength = arr.Count();

            if (arrLength == 0 || arrLength == 1)
            {
                return 0;
            }

            int[] firstPartOfTheArr = MergeSortHelperMethods.GetArrFirstPart(arr);
            long numberOfFirstPartInversions = DivideAndConquerApproach(firstPartOfTheArr);

            int[] secondPartOfTheArr = MergeSortHelperMethods.GetSecondPart(arr);
            long secondPartNumberOfInversions = DivideAndConquerApproach(secondPartOfTheArr);

            int numberOfSplittedInversions = HelperMethods.MergeAndCountNumberOfInversions(firstPartOfTheArr, secondPartOfTheArr, arr);

            return numberOfFirstPartInversions + secondPartNumberOfInversions + numberOfSplittedInversions;
        }

    }
}
