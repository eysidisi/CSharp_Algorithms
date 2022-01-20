using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Sort.QuickSortAlgorithm;

namespace Algorithms.Part1.Tests.Sort.QuickSortAlgorithmTests.HelperMethodsTests
{
    public class SwapTests
    {
        [Fact]
        public void TwoElementArray()
        {
            // Arrange 
            var array = new int[] { 1, 2 };
            var helperMethods = new HelperMethods();
            var expectedOutput = new int[] { 2, 1 };

            // Act
            helperMethods.Swap(ref array, 0, 1);

            // Assert
            Assert.Equal(expectedOutput, array);
        }
    }
}
