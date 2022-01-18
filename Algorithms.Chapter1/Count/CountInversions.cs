using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Part1.Sort;
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

        public long DivideAndConquerApproach(ref int[] arr)
        {
            Sort.HelperMethods sortHelperMethods = new Sort.HelperMethods();
            HelperMethods helperMethods = new HelperMethods();

            int arrLength = arr.Count();

            if (arrLength == 0 || arrLength == 1)
            {
                return 0;
            }

            int[] firstPartOfTheArr = sortHelperMethods.FirstPart(arr);
            long numberOfFirstPartInversions = DivideAndConquerApproach(ref firstPartOfTheArr);

            int[] secondPartOfTheArr = sortHelperMethods.SecondPart(arr);
            long secondPartNumberOfInversions = DivideAndConquerApproach(ref secondPartOfTheArr);

            int numberOfSplittedInversions = helperMethods.MergeAndCountNumberOfInversions(firstPartOfTheArr, secondPartOfTheArr, ref arr);

            return numberOfFirstPartInversions + secondPartNumberOfInversions + numberOfSplittedInversions;
        }

        public long DivideAndConquerApproach(string inputFilePath)
        {
            HelperMethods helperMethods = new HelperMethods();
            
            int[] input = helperMethods.ReadInput(inputFilePath);

            return DivideAndConquerApproach(ref input);
        }

    }
}
