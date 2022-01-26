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
    public class ReadGraph
    {
        [Fact]
        public void TwoVerticesMatrix()
        {
            // Arrange
            string path = Directory.GetCurrentDirectory() + @"\Graph\File\TwoVerticesMatrix.txt";
            var expectedGraph = new Part1.Graph.GraphRepresentation(2);
            var fileManager = new FileManager();

            expectedGraph.AddEdge(0, 1);

            // Act
            var actualGraph=fileManager.ReadGraph(path);

            // Assert
            Assert.Equal(expectedGraph, actualGraph);   
        }
    }
}
