namespace Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms
{
    public interface IFindPivotAlgorithm
    {
        public int ChoosePivotIndex(int leftIndex, int rightIndex, ref int[] arr);
    }
}