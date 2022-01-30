using Algorithms.Part1.Sort.QuickSortAlgorithm;
using Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Search.RSelectionAlgorithm
{
    public class RSelection
    {

        IFindPivotAlgorithm pivotAlgorithm;
        HelperMethods helperMethods;

        public RSelection(IFindPivotAlgorithm pivotAlgorithm)
        {
            this.pivotAlgorithm = pivotAlgorithm;
            helperMethods = new HelperMethods();
        }

        /// <summary>
        /// Finds kth order statistic in an array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="numberOfOrder"></param>
        /// <returns></returns>
        public int FindOrderStatistic(int[] arr, int k)
        {
            if (k < 1)
                throw new ArgumentException("k needs to be equal or larger than 1");

            return FindKthOrderStatistic(ref arr, 0, arr.Length - 1, k - 1);
        }

        private int FindKthOrderStatistic(ref int[] arr, int leftIndex, int rightIndex, int k)
        {
            if (arr.Count() == 1)
            {
                return arr[0];
            }

            // Find a pivot index
            int pivotIndex = pivotAlgorithm.ChoosePivotIndex(leftIndex, rightIndex, ref arr);

            // Partition array using that pivot element
            int correctPivotIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            if (correctPivotIndex == k)
            {
                return arr[correctPivotIndex];
            }

            if (k > correctPivotIndex)
            {
                return FindKthOrderStatistic(ref arr, correctPivotIndex + 1, rightIndex, k);
            }

            else
            {
                return FindKthOrderStatistic(ref arr, leftIndex, correctPivotIndex - 1, k);
            }
        }
    }
}
