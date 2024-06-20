namespace Algorithms.Part1.Search
{
    public static class ChapterThreeChallengeProblems
    {
        //  You are given a unimodal array of n distinct elements,
        //  meaning that its entries are in increasing order up until its maximum element, after which
        //  its elements are in decreasing order.
        //  Give an algorithm to compute the maximum element of a unimodal array
        //  that runs in O(log n) time.

        public static int FindMaxInUnimodalArray(int[] arr)
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


        public static int FindMaxInUnimodalArrayRecursive(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr[0];
            }

            if (IsArrayIncreasing(arr))
            {
                return arr.Last();
            }
            else if (IsArrayDecreasing(arr))
            {
                return arr.First();
            }
            else
            {
                int middIndex = arr.Length / 2;
                var firstHalf = arr.Take(middIndex).ToArray();
                var secondHalf = arr.Skip(middIndex).ToArray();
                return Math.Max(FindMaxInUnimodalArrayRecursive(firstHalf), FindMaxInUnimodalArrayRecursive(secondHalf));
            }
        }

        private static bool IsArrayDecreasing(int[] arr)
        {
            return arr[1] < arr[0] && arr.Last() < arr[arr.Length - 2];
        }

        private static bool IsArrayIncreasing(int[] arr)
        {
            return arr[1] > arr[0] && arr.Last() > arr[arr.Length - 2];
        }


        //  You are given a sorted(from smallest to largest) array
        //  A of n distinct integers which can be positive, negative, or zero.
        //  You want to decide whether or not there is an index i such that A[i] = i.
        //  Design the fastest algorithm you can for solving this problem.

        public static bool CheckIndexEqualsToTheValue(int[] arr)
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
