using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.HeapAlgorithms
{
    public class MaxHeap : Heap
    {
        public MaxHeap(int size = 1000) : base(size)
        {
        }

        protected override void BubbleDownIfNecessary(int elementIndex)
        {
            throw new NotImplementedException();
        }

        protected override void BubbleUpIfNecessary(int elementIndex)
        {
            throw new NotImplementedException();
        }
    }
}
