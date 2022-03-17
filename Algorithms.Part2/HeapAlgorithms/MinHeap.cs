using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.HeapAlgorithms
{
    public class MinHeap : Heap
    {
        public MinHeap(int size = 1000) : base(size)
        {
        }

        protected override void BubbleDownIfNecessary(int parentNodeIndex)
        {
            int parentNode = arr[parentNodeIndex];
            int firstChildNodeIndex = parentNodeIndex * 2 + 1;
            int secondChildNodeIndex = firstChildNodeIndex + 1;

            // Has two children
            if (secondChildNodeIndex <= NumOfElements - 1)
            {
                int firstChild = arr[firstChildNodeIndex];
                int secondChild = arr[secondChildNodeIndex];

                int childIndexToSwap = firstChild < secondChild ? firstChildNodeIndex : secondChildNodeIndex;

                if (parentNode > arr[childIndexToSwap])
                {
                    Swap(parentNodeIndex, childIndexToSwap);
                    BubbleDownIfNecessary(childIndexToSwap);
                }

                else
                {
                    return;
                }
            }

            // Has one child
            else if (firstChildNodeIndex <= NumOfElements - 1)
            {
                int firstChild = arr[firstChildNodeIndex];

                if (parentNode > firstChild)
                {
                    Swap(parentNodeIndex, firstChildNodeIndex);
                }

                else
                {
                    return;
                }
            }

            // Has no children
            else
            {
                return;
            }
        }

        protected override void BubbleUpIfNecessary(int childNodeIndex)
        {
            int parentNodeIndex = childNodeIndex / 2;
            int parentNode = arr[parentNodeIndex];
            int childNode = arr[childNodeIndex];

            if (childNode >= parentNode)
            {
                return;
            }

            else
            {
                Swap(childNodeIndex, parentNodeIndex);
                BubbleUpIfNecessary(parentNodeIndex);
            }
        }
    }
}
