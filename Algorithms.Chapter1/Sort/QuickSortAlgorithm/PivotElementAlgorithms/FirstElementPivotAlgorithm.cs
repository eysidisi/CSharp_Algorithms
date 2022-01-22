using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms
{
    /// <summary>
    /// Returns first index as pivot index
    /// </summary>
    public class FirstElementPivotAlgorithm : IFindPilotAlgorithm
    {
        public int ChoosePivotIndex(int leftIndex, int rightIndex,ref int[] arr)
        {
            return leftIndex;
        }
    }
}
