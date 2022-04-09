using Algorithms.Part3.GreedyAlgorithms.MinimumSpanningTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part3.Tests.GreedyAlgorithms.MinimumSpanningTree
{
    public class TreeTests
    {
        [Fact]
        public void FindMinimumSpanningTreeTotalCost_TwoNodes_ReturnsCost()
        {
            // Arrange
            Tree tree = new Tree(2, 1);
            tree.AddEdge(0, 1, 4);

            long expectedCost = 4;

            // Act
            long actualCost = tree.FindMinimumSpanningTreeTotalCost();

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void FindMinimumSpanningTreeTotalCost_ThreeNodesSameEdgeLength_ReturnsCost()
        {
            // Arrange
            Tree tree = new Tree(3, 1);
            tree.AddEdge(0, 1, 4);
            tree.AddEdge(1, 2, 4);

            long expectedCost = 8;

            // Act
            long actualCost = tree.FindMinimumSpanningTreeTotalCost();

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void FindMinimumSpanningTreeTotalCost_ThreeNodesDifferentEdgeLength_ReturnsCost()
        {
            // Arrange
            Tree tree = new Tree(3, 1);
            tree.AddEdge(0, 1, 4);
            tree.AddEdge(1, 2, 3);

            long expectedCost = 7;

            // Act
            long actualCost = tree.FindMinimumSpanningTreeTotalCost();

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void FindMinimumSpanningTreeTotalCost_FourNodesDifferentEdgeLength_ReturnsCost()
        {
            // Arrange
            Tree tree = new Tree(4, 5);
            tree.AddEdge(0, 1, 4);
            tree.AddEdge(0, 3, 1);
            tree.AddEdge(0, 2, 3);

            tree.AddEdge(1, 2, 5);

            tree.AddEdge(2, 3, 2);

            long expectedCost = 7;

            // Act
            long actualCost = tree.FindMinimumSpanningTreeTotalCost();

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void FindMinimumSpanningTreeTotalCost_ComplexTree_ReturnsCost()
        {
            // Arrange
            Tree tree = new Tree(9, 14);
            tree.AddEdge(7, 6, 1);
            tree.AddEdge(8, 2, 2);
            tree.AddEdge(6, 5, 2);
            tree.AddEdge(0, 1, 4);
            tree.AddEdge(2, 5, 4);
            tree.AddEdge(8, 6, 6);
            tree.AddEdge(2, 3, 7);
            tree.AddEdge(7, 8, 7);
            tree.AddEdge(0, 7, 8);
            tree.AddEdge(1, 2, 8);
            tree.AddEdge(3, 4, 9);
            tree.AddEdge(5, 4, 10);
            tree.AddEdge(1, 7, 11);
            tree.AddEdge(3, 5, 14);

            long expectedCost = 37;

            // Act
            long actualCost = tree.FindMinimumSpanningTreeTotalCost();

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void CourseraAssignment()
        {
            // Arrange
            Tree tree = new Tree();
            string path = Directory.GetCurrentDirectory() + @"\GreedyAlgorithms\MinimumSpanningTree\InputFiles\MST.txt";

            // Act
            long actualCost = tree.FindMinimumSpanningTreeTotalCost(path);

        }
    }
}
