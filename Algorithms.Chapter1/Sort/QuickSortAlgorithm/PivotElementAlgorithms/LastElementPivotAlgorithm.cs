using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms
{
    public class LastElementPivotAlgorithm : IFindPivotAlgorithm
    {
        public int ChoosePivotIndex(int leftIndex, int rightIndex,ref int[] arr)
        {
            return rightIndex;
        }
    }
}
