namespace Algorithms.Part2.HeapAlgorithms
{
    public interface IMaxHeap
    {
        int Count();
        void Enqueue(int element);
        int First();
    }
}