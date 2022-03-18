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
        Heap maxHeap;
        Heap minHeap;

        public MedianMaintenance(Heap minHeap, Heap maxHeap)
        {
            this.maxHeap = maxHeap;
            this.minHeap = minHeap;
        }

        public int GetMedian()
        {
            if (maxHeap.NumOfElements >= minHeap.NumOfElements)
            {
                return maxHeap.Peek();
            }

            else
            {
                return minHeap.Peek();
            }
        }
        public void AddElement(int element)
        {
            // Heaps has no element
            if (maxHeap.NumOfElements == 0 && minHeap.NumOfElements == 0)
            {
                maxHeap.Enqueue(element);
            }

            else
            {
                if (maxHeap.Peek() > element)
                {
                    maxHeap.Enqueue(element);
                }
                else
                {
                    minHeap.Enqueue(element);
                }
            }

            if (Math.Abs(maxHeap.NumOfElements - minHeap.NumOfElements) > 1)
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
            if (maxHeap.NumOfElements > minHeap.NumOfElements)
            {
                int numToAdd = maxHeap.Dequeue();
                minHeap.Enqueue(numToAdd);
            }

            else
            {
                int numToAdd = minHeap.Dequeue();
                maxHeap.Enqueue(numToAdd);
            }
        }
    }
}
