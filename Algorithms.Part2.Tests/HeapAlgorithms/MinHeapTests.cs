using Algorithms.Part2.HeapAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part2.Tests.HeapAlgorithms
{
    public class MinHeapTests
    {
        [Theory]
        [InlineData(new int[] { 1, 3, 4, 5, 6, 7, 8, 2 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 0 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7 })]
        [InlineData(new int[] { 1, 2, 3, 5, 6, 7, 8, 4 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new int[] { 1, 3, 2, 5, 6, 7, 8, 4 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void Dequeu_ReturnsItemsInOrder(int[] input, int[] expected)
        {
            // Arrange
            MinHeap heap = new MinHeap();

            // Act
            foreach (var item in input)
            {
                heap.Enqueue(item);
            }

            List<int> actual = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                actual.Add(heap.Dequeue());
            }

            // Assert
            Assert.Equal(expected.ToList(), actual);
        }
    }
}
