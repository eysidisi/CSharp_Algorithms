namespace Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms
{
    public interface IFindPilotAlgorithm
    {
        public int ChoosePivotIndex(int leftIndex, int rightIndex, ref int[] arr);
    }
}