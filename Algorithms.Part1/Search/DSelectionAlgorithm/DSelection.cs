using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Part1.Sort.QuickSortAlgorithm;


namespace Algorithms.Part1.Search.DSelectionAlgorithm
{
    public class DSelection
    {
        Sort.QuickSortAlgorithm.HelperMethods quickSortHelperMethods = new Sort.QuickSortAlgorithm.HelperMethods();

        HelperMethods DSelectHelperMethods = new HelperMethods();
        public int FindOrderStatistic(int[] arr, int k)
        {
            return FindKthOrderStatistic(arr, k - 1);
        }
        private int FindKthOrderStatistic(int[] arr, int k)
        {
            if (arr.Length == 1)
            {
                return arr[0];
            }

            List<int[]> groupedArrays = DSelectHelperMethods.GroupArraysIntoFive(arr);

            int[] medianArr = DSelectHelperMethods.FindMedians(groupedArrays);

            int pivotInteger = FindKthOrderStatistic(medianArr, medianArr.Length / 2);

            int pivotIndexBeforePartition = Array.IndexOf(arr, pivotInteger);

            int pivotIndexAfterPartition = quickSortHelperMethods.PartitionArr(ref arr, 0, arr.Length - 1, pivotIndexBeforePartition);

            if (pivotIndexAfterPartition == k)
            {
                return pivotInteger;
            }

            else if (pivotIndexAfterPartition > k)
            {
                var subArr = new int[pivotIndexAfterPartition];
                Array.Copy(arr, 0, subArr, 0, subArr.Length);
                return FindKthOrderStatistic(subArr, k);
            }

            else
            {
                var subArr = new int[arr.Length - pivotIndexAfterPartition - 1];
                Array.Copy(arr, pivotIndexAfterPartition + 1, subArr, 0, subArr.Length);
                return FindKthOrderStatistic(subArr, k - pivotIndexAfterPartition - 1);
            }
        }
    }
}
