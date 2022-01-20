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

        public void Sort(ref int[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            int beforeSortPivotIndex = FindPilotIndexAlgorithm.FindPivotIndex(leftIndex, rightIndex);

            int afterSortPivotIndex = HelperMethods.PartitionArr(ref arr, leftIndex, rightIndex, beforeSortPivotIndex);

            Sort(ref arr, leftIndex, afterSortPivotIndex - 1);

            Sort(ref arr, afterSortPivotIndex + 1, rightIndex);
        }

    }
}
