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
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 7, 6, 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [InlineData(new int[] { 7, 5, 6, 3, 1, 4, 2 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [InlineData(new int[] { 7, 5, 6, 3, 1, 7, 4, 2 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 7 })]
        public void Dequeu_ReturnsItemsInOrder(int[] input, int[] expected)
        {
            // Arrange
            MinHeap heap = new MinHeap();

            // Act
            foreach (var item in input)
            {
                heap.Enqueu(item);
            }

            List<int> actual = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                actual.Add(heap.Dequeu());
            }

            // Assert
            Assert.Equal(expected.ToList(), actual);
        }
    }
}
