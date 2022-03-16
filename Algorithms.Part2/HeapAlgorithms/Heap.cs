using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.HeapAlgorithms
{
    public abstract class Heap
    {
        protected int[] arr;
        protected int numOfElements;

        public Heap(int size)
        {
            numOfElements = 0;
            arr = new int[size];
        }

        public void Enqueu(int num)
        {
            if (numOfElements > arr.Length)
            {
                throw new Exception("Need a bigger heap!");
            }

            arr[numOfElements] = num;
            numOfElements++;

            BubbleUpIfNecessary(numOfElements - 1);
        }

        public int Dequeu()
        {
            if (numOfElements == 0)
            {
                throw new Exception("No element left in the heap!");
            }

            int numToReturn = arr[0];
            arr[0] = arr[numOfElements - 1];
            numOfElements--;

            BubbleDownIfNecessary(0);

            return numToReturn;
        }

        protected void Swap(int childNodeIndex, int parentNodeIndex)
        {
            int temp = arr[childNodeIndex];
            arr[childNodeIndex] = arr[parentNodeIndex];
            arr[parentNodeIndex] = temp;
        }

        protected abstract void BubbleUpIfNecessary(int elementIndex);

        protected abstract void BubbleDownIfNecessary(int elementIndex);
    }
}
