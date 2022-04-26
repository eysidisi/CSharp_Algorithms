using Algorithms.Part3.DynamicProgramming.Knapsack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part3.Tests.DynamicProgramming.Knapsack
{
    public class KnapsackAlgorithmTests
    {
        [Theory]
        [InlineData(3, 5, 3, 5)]
        [InlineData(2, 5, 5, 5)]
        [InlineData(3, 5, 2, 0)]
        public void CalculateMaxWeight_OneItem_ReturnsWeight(int value, int weight, int knapsackSize, int expectedTotalWeight)
        {
            Item item = new Item(value, weight);
            Item[] items = new Item[] { item };
            KnapsackAlgorithm knapsackAlgorithm = new KnapsackAlgorithm(items);

            long actualTotalWeight = knapsackAlgorithm.CalculateMaxWeight(knapsackSize);

            Assert.Equal(expectedTotalWeight, actualTotalWeight);
        }


        [Theory]
        [InlineData(new int[] { 1, 4 }, new int[] { 5, 7 }, 1, 5)]
        [InlineData(new int[] { 1, 4 }, new int[] { 5, 7 }, 3, 5)]
        [InlineData(new int[] { 1, 4 }, new int[] { 5, 7 }, 4, 7)]
        [InlineData(new int[] { 1, 4 }, new int[] { 5, 7 }, 5, 12)]
        [InlineData(new int[] { 1, 4 }, new int[] { 5, 7 }, 6, 12)]
        public void CalculateMaxWeight_TwoItems_ReturnsWeight(int[] values, int[] weights, int knapsackSize, int expectedTotalWeight)
        {
            Item[] items = new Item[2];

            items[0] = new Item(values[0], weights[0]);
            items[1] = new Item(values[1], weights[1]);

            KnapsackAlgorithm knapsackAlgorithm = new KnapsackAlgorithm(items);

            long actualTotalWeight = knapsackAlgorithm.CalculateMaxWeight(knapsackSize);

            Assert.Equal(expectedTotalWeight, actualTotalWeight);
        }

        [Fact]
        public void CalculateMaxWeight_Complex_ReturnsWeight()
        {
            Item[] items = new Item[]
            {
                new Item(4,3),
                new Item(3,2),
                new Item(2,4),
                new Item(3,4)
            };

            KnapsackAlgorithm knapsackAlgorithm = new KnapsackAlgorithm(items);

            int knapsackSize = 6;
            long expectedTotalWeight = 8;

            long actualTotalWeight = knapsackAlgorithm.CalculateMaxWeight(knapsackSize);

            Assert.Equal(expectedTotalWeight, actualTotalWeight);
        }

        [Fact]
        public void CourseraAssignment_SmallInput()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\DynamicProgramming\Knapsack\InputFiles\knapsack.txt";
            int knapsackSize;
            Item[] items = ReadInputFile(filePath, out knapsackSize);

            KnapsackAlgorithm knapsackAlgorithm = new KnapsackAlgorithm(items);

            long actualTotalWeight = knapsackAlgorithm.CalculateMaxWeight(knapsackSize);

            Assert.Equal(2493893, actualTotalWeight);
        }

        [Fact(Skip ="Takes too much time!")]
        public void CourseraAssignment_BigInput()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\DynamicProgramming\Knapsack\InputFiles\knapsack_big.txt";
            int knapsackSize;
            Item[] items = ReadInputFile(filePath, out knapsackSize);

            KnapsackAlgorithm knapsackAlgorithm = new KnapsackAlgorithm(items);

            long actualTotalWeight = knapsackAlgorithm.CalculateMaxWeight(knapsackSize);

            Assert.Equal(4243395, actualTotalWeight);
        }

        private Item[] ReadInputFile(string filePath, out int knapsackSize)
        {
            string[] lines = File.ReadAllLines(filePath);

            knapsackSize = int.Parse(lines[0].Split(" ")[0]);
            int numberOfItems = int.Parse(lines[0].Split(" ")[1]);

            Item[] items = new Item[numberOfItems];

            for (int lineIndex = 1; lineIndex < lines.Length; lineIndex++)
            {
                int weight = int.Parse(lines[lineIndex].Split(" ")[0]);
                int value = int.Parse(lines[lineIndex].Split(" ")[1]);
                items[lineIndex - 1] = new Item(value, weight);
            }

            return items;
        }
    }
}
