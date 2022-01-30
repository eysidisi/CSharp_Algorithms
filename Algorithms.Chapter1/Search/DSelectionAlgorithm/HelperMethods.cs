using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Search.DSelectionAlgorithm
{
    public class HelperMethods
    {
        public int[] FindMedians(List<int[]> groupedArrays)
        {
            List<int> result = new List<int>();

            foreach (var arr in groupedArrays)
            {
                result.Add(FindMedian(arr));
            }

            return result.ToArray();
        }

        private int FindMedian(int[] arr)
        {
            int middleIndex = (int)Math.Ceiling(arr.Length / 2.0) - 1;
            return arr.OrderBy(x => x).ToArray()[middleIndex];
        }

        public List<int[]> GroupArraysIntoFive(int[] arr)
        {
            List<int[]> result = new List<int[]>();

            List<int> groupedArr = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i != 0 && i % 5 == 0)
                {
                    result.Add(groupedArr.ToArray());
                    groupedArr = new List<int>();
                }

                groupedArr.Add(arr[i]);
            }

            if (groupedArr.Count() != 0)
            {
                result.Add(groupedArr.ToArray());
            }

            return result;
        }

    }
}
