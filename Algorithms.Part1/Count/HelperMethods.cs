namespace Algorithms.Part1.Count
{
    public static class HelperMethods
    {
        public static int MergeAndCountNumberOfInversions(int[] firstPartOfTheArr, int[] secondPartOfTheArr, int[] mergedArr)
        {
            int firstPartIndex = 0;
            int secondPartIndex = 0;
            int mergedArrIndex = 0;
            int numOfInversions = 0;

            while (mergedArrIndex < mergedArr.Length)
            {
                if (firstPartIndex >= firstPartOfTheArr.Length)
                {
                    mergedArr[mergedArrIndex] = secondPartOfTheArr[secondPartIndex];
                    secondPartIndex++;
                }

                else if (secondPartIndex >= secondPartOfTheArr.Length)
                {
                    mergedArr[mergedArrIndex] = firstPartOfTheArr[firstPartIndex];
                    firstPartIndex++;
                }

                else
                {
                    if (secondPartOfTheArr[secondPartIndex] >= firstPartOfTheArr[firstPartIndex])
                    {
                        mergedArr[mergedArrIndex] = firstPartOfTheArr[firstPartIndex];
                        firstPartIndex++;
                    }
                    else
                    {
                        mergedArr[mergedArrIndex] = secondPartOfTheArr[secondPartIndex];
                        secondPartIndex++;
                        numOfInversions += firstPartOfTheArr.Length - firstPartIndex;
                    }
                }

                mergedArrIndex++;
            }

            return numOfInversions;
        }
    }
}
