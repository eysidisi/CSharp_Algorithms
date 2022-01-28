using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Count;
using Algorithms.Part1.FileIO;

namespace Algorithms.Part1.Tests.FileIO
{
    public class ReadFileIntoIntArray
    {
        [Fact]
        public void ReadOneElement()
        {
            // Arrange 
            var fileManager = new FileManager();
            string filePath = Directory.GetCurrentDirectory() + @"\FileIO\TestFiles\OneElement.txt";
            var expectedOutput = new int[] { 123 };

            // Act
            var actualOutput = fileManager.ReadFileIntoIntArray(filePath);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ReadThreeElements()
        {
            // Arrange 
            var fileManager = new FileManager();
            string filePath = Directory.GetCurrentDirectory() + @"\FileIO\TestFiles\ThreeElements.txt";
            var expectedOutput = new int[] { 123, 456, 789 };

            // Act
            var actualOutput = fileManager.ReadFileIntoIntArray(filePath);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

    }
}
