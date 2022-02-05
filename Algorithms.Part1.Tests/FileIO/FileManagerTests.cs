using Algorithms.Part1.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part1.Tests.FileIO
{
    public class FileManagerTests
    {
        [Fact]
        public void ReadFileIntoIntArray_ReadOneElement()
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
        public void ReadFileIntoIntArray_ReadThreeElements()
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
        [Fact]
        public void ReadGraph_TwoVerticesMatrix()
        {
            // Arrange
            string path = Directory.GetCurrentDirectory() + @"\Graph\TestFiles\TwoVerticesMatrix.txt";
            var expectedGraph = new Part1.Graph.GraphRepresentation(2);
            var fileManager = new FileManager();

            expectedGraph.AddEdge(0, 1);

            // Act
            var actualGraph = fileManager.ReadGraph(path);

            // Assert
            Assert.Equal(expectedGraph, actualGraph);
        }

        [Fact]
        public void ReadGraph_FiveMatrix()
        {
            // Arrange
            string path = Directory.GetCurrentDirectory() + @"\Graph\TestFiles\FiveVerticesMatrix.txt";
            var expectedGraph = new Part1.Graph.GraphRepresentation(5);
            var fileManager = new FileManager();

            expectedGraph.AddEdge(0, 1);
            expectedGraph.AddEdge(0, 2);
            expectedGraph.AddEdge(1, 2);
            expectedGraph.AddEdge(1, 3);
            expectedGraph.AddEdge(2, 3);
            expectedGraph.AddEdge(2, 4);
            expectedGraph.AddEdge(3, 4);

            // Act
            var actualGraph = fileManager.ReadGraph(path);

            // Assert
            Assert.Equal(expectedGraph, actualGraph);
        }
    }
}
