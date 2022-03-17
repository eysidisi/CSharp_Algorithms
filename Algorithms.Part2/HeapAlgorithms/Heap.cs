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
        public int NumOfElements { get; protected set; }
        public Heap(int size)
        {
            NumOfElements = 0;
            arr = new int[size];
        }

        public void Enqueu(int num)
        {
            if (NumOfElements >= arr.Length)
            {
                throw new Exception("Need a bigger heap!");
            }

            arr[NumOfElements] = num;
            NumOfElements++;

            BubbleUpIfNecessary(NumOfElements - 1);
        }

        public int Dequeu()
        {
            if (NumOfElements == 0)
            {
                throw new Exception("No element left in the heap!");
            }

            int numToReturn = arr[0];
            arr[0] = arr[NumOfElements - 1];
            NumOfElements--;

            BubbleDownIfNecessary(0);

            return numToReturn;
        }
        public int Peek()
        {
            return arr[0];
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
