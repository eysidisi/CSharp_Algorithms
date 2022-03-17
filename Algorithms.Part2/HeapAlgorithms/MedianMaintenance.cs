using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace Algorithms.Part2.HeapAlgorithms
{
    public class MedianMaintenance
    {
        SimplePriorityQueue<int> maxHeap = new SimplePriorityQueue<int>();
        SimplePriorityQueue<int> minHeap = new SimplePriorityQueue<int>();

        public int GetMedian()
        {
            if (maxHeap.Count >= minHeap.Count)
            {
                return maxHeap.First;
            }

            else
            {
                return minHeap.First();
            }
        }
        public void AddElement(int element)
        {
            // Heaps has no element
            if (maxHeap.Count == 0 && minHeap.Count == 0)
            {
                int priority = -1 * element;
                maxHeap.Enqueue(element, priority);
            }

            else
            {
                if (maxHeap.First() > element)
                {
                    int priority = -1 * element;
                    maxHeap.Enqueue(element, priority);
                }
                else
                {
                    minHeap.Enqueue(element, element);
                }
            }

            if (Math.Abs(maxHeap.Count - minHeap.Count) > 1)
            {
                BalanceHeaps();
            }
        }

        public List<int> ReadInputFile(string path)
        {
            List<int> input = new List<int>();

            var inputLines = File.ReadLines(path);

            foreach (var line in inputLines)
            {
                input.Add(int.Parse(line));
            }

            return input;
        }

        private void BalanceHeaps()
        {
            if (maxHeap.Count > minHeap.Count)
            {
                int numToAdd = maxHeap.Dequeue();
                minHeap.Enqueue(numToAdd, numToAdd);
            }

            else
            {
                int numToAdd = minHeap.Dequeue();
                int priority = -1 * numToAdd;
                maxHeap.Enqueue(numToAdd, priority);
            }
        }
    }
}
