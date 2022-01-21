using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms
{
    public class MedianOfThreePivotAlgorithm : IFindPilotAlgorithm
    {
        public int FindPivotIndex(int leftIndex, int rightIndex, ref int[] arr)
        {
            return FindMedianIndex(leftIndex, rightIndex, ref arr);
        }

        private int FindMedianIndex(int firstElementIndex, int lastElementIndex, ref int[] arr)
        {
            int firstElement = arr[firstElementIndex];

            int middleElementIndex = (lastElementIndex - firstElementIndex) / 2;
            int middleElement = arr[middleElementIndex];

            int lastElement = arr[lastElementIndex];

            if (lastElementIndex - firstElementIndex == 1)
            {
                return firstElementIndex;
            }

            if (firstElement == lastElement || firstElement == middleElement || middleElement == lastElement)
            {
                throw new ArgumentException("Need distinct elements!");
            }

            if (firstElement > middleElement && firstElement > lastElement)
            {
                if (middleElement > lastElement)
                {
                    return middleElementIndex;
                }
                else
                {
                    return lastElementIndex;
                }
            }

            else if (middleElement > firstElement && middleElement > lastElement)
            {
                if (firstElement > lastElement)
                {
                    return firstElementIndex;
                }
                else
                {
                    return lastElementIndex;
                }
            }

            else
            {
                if (firstElement > middleElement)
                {
                    return firstElementIndex;
                }
                else
                {
                    return middleElementIndex;
                }
            }
        }
    }
}
