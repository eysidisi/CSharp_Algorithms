using Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Sort.QuickSortAlgorithm
{
    public class QuickSort
    {
        IFindPilotAlgorithm FindPilotIndexAlgorithm;
        HelperMethods HelperMethods = new HelperMethods();
        public QuickSort(IFindPilotAlgorithm findPilotAlgorithm)
        {
            this.FindPilotIndexAlgorithm = findPilotAlgorithm;
        }

        // This variable is just used for coursera assignments
        public int NumOfComparisons { get;private set; }

        public void Sort(ref int[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            NumOfComparisons += rightIndex - leftIndex;

            int beforeSortPivotIndex = FindPilotIndexAlgorithm.FindPivotIndex(leftIndex, rightIndex,ref arr);

            int afterSortPivotIndex = HelperMethods.PartitionArr(ref arr, leftIndex, rightIndex, beforeSortPivotIndex);

            Sort(ref arr, leftIndex, afterSortPivotIndex - 1);

            Sort(ref arr, afterSortPivotIndex + 1, rightIndex);
        }

    }
}
