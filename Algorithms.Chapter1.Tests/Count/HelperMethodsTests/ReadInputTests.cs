using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Count;

namespace Algorithms.Part1.Tests.Count.HelperMethodsTests
{
    public class ReadInputTests
    {
        [Fact]
        public void ReadOneElement()
        {
            // Arrange 
            HelperMethods helperMethods = new HelperMethods();
            string filePath = Directory.GetCurrentDirectory() + @"\Count\HelperMethodsTests\TextFiles\OneElement.txt";
            var expectedOutput = new int[] { 123 };

            // Act
            var actualOutput = helperMethods.ReadInput(filePath);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ReadThreeElements()
        {
            // Arrange 
            HelperMethods helperMethods = new HelperMethods();
            string filePath = Directory.GetCurrentDirectory() + @"\Count\HelperMethodsTests\TextFiles\ThreeElements.txt";
            var expectedOutput = new int[] { 123, 456, 789 };

            // Act
            var actualOutput = helperMethods.ReadInput(filePath);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

    }
}
