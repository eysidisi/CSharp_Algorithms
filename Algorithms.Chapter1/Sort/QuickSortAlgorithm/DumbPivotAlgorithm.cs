using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Sort.QuickSortAlgorithm
{
    /// <summary>
    /// Returns first index as pivot index
    /// </summary>
    public class DumbPivotAlgorithm : IFindPilotAlgorithm
    {
        public int FindPivotIndex(int leftIndex, int rightIndex)
        {
            return leftIndex;
        }
    }
}
