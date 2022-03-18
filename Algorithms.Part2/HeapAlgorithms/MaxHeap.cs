using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.HeapAlgorithms
{
    public class MaxHeap : Heap
    {
        public MaxHeap(int size = 5000) : base(size)
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

                int childIndexToSwap = firstChild > secondChild ? firstChildNodeIndex : secondChildNodeIndex;

                if (arr[childIndexToSwap] > parentNode)
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

                if (firstChild > parentNode)
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
            if (childNodeIndex == 0)
                return;

            int parentNodeIndex = childNodeIndex / 2;

            if (childNodeIndex % 2 == 0)
            {
                parentNodeIndex--;
            }

            int parentNode = arr[parentNodeIndex];
            int childNode = arr[childNodeIndex];

            if (parentNode >= childNode)
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
