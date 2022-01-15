using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Search
{
    public class ChapterThreeChallengeProblems
    {
        //  You are given a unimodal array of n distinct elements,
        //  meaning that its entries are in increasing order up until its maximum element, after which
        //  its elements are in decreasing order.
        //  Give an algorithm to compute the maximum element of a unimodal array
        //  that runs in O(log n) time.

        public int FindMaxInUnimodalArray(int[] arr)
        {
            if (arr.Length < 3)
            {
                throw new ArgumentException("Array needs to have two elements at least!");
            }


            int startingIndex = 0;
            int endingIndex = arr.Length - 1;

            while (true)
            {
                int middleIndex = startingIndex + (endingIndex - startingIndex) / 2;

                if (arr[middleIndex] > arr[middleIndex - 1])
                {
                    startingIndex = middleIndex;
                }
                else
                {
                    endingIndex = middleIndex;
                }

                if (endingIndex - startingIndex == 1)
                {
                    return arr[startingIndex];
                }
            }
        }

        //  You are given a sorted(from smallest to largest) array
        //  A of n distinct integers which can be positive, negative, or zero.
        //  You want to decide whether or not there is an index i such that A[i] = i.
        //  Design the fastest algorithm you can for solving this problem.

        public bool CheckIndexEqualsToTheValue(int[] arr)
        {
            int startingIndex = 0;
            int endIndex = arr.Length - 1;

            while (endIndex >= startingIndex)
            {
                int middleIndex = startingIndex + (endIndex - startingIndex) / 2;

                if (arr[middleIndex] == middleIndex)
                {
                    return true;
                }

                else if (arr[middleIndex] > middleIndex)
                {
                    endIndex = middleIndex - 1;
                }

                else
                {
                    startingIndex = middleIndex + 1;
                }
            }
            return false;
        }
    }
}
