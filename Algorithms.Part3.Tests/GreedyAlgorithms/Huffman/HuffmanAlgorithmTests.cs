using Algorithms.Part3.GreedyAlgorithms.Huffman;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part3.Tests.GreedyAlgorithms.Huffman
{
    public class HuffmanAlgorithmTests
    {

        [Fact]
        public void CalculateMaxLengthOfCodeword_TwoSymbols_ReturnsOne()
        {
            int[] symbolWeights = new int[] { 5, 3 };
            HuffmanAlgorithm huffmanAlgorithm = new HuffmanAlgorithm(symbolWeights);
            int expectedResult = 1;

            int actualResult = huffmanAlgorithm.CalculateMaxLengthOfCodeword();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CalculateMaxLengthOfCodeword_ThreeSymbols_ReturnsTwo()
        {
            int[] symbolWeights = new int[] { 5, 3, 1 };
            HuffmanAlgorithm huffmanAlgorithm = new HuffmanAlgorithm(symbolWeights);
            int expectedResult = 2;

            int actualResult = huffmanAlgorithm.CalculateMaxLengthOfCodeword();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CalculateMaxLengthOfCodeword_FourSymbols_ReturnsTwo()
        {
            int[] symbolWeights = new int[] { 4, 5, 6, 7 };
            HuffmanAlgorithm huffmanAlgorithm = new HuffmanAlgorithm(symbolWeights);
            int expectedResult = 2;

            int actualResult = huffmanAlgorithm.CalculateMaxLengthOfCodeword();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CalculateMaxLengthOfCodeword_FourSymbols_ReturnsThree()
        {
            int[] symbolWeights = new int[] { 10, 4, 8, 5 };
            HuffmanAlgorithm huffmanAlgorithm = new HuffmanAlgorithm(symbolWeights);
            int expectedResult = 3;

            int actualResult = huffmanAlgorithm.CalculateMaxLengthOfCodeword();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CalculateMaxLengthOfCodeword_FiveSymbols_ReturnsThree()
        {
            int[] symbolWeights = new int[] { 10, 11, 4, 6, 12 };
            HuffmanAlgorithm huffmanAlgorithm = new HuffmanAlgorithm(symbolWeights);
            int expectedResult = 3;

            int actualResult = huffmanAlgorithm.CalculateMaxLengthOfCodeword();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CalculateMaxLengthOfCodeword_CourseraAssignment()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\GreedyAlgorithms\Huffman\InputFiles\huffman.txt";

            HuffmanAlgorithm huffman = new HuffmanAlgorithm(filePath);
            
            int expectedResult = 19;
            int actualResult = huffman.CalculateMaxLengthOfCodeword();

            Assert.Equal(expectedResult,actualResult);
        }

        [Fact]
        public void CalculateMinLengthOfCodeword_TwoSymbols_ReturnsOne()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\GreedyAlgorithms\Huffman\InputFiles\huffman.txt";

            HuffmanAlgorithm huffman = new HuffmanAlgorithm(filePath);

            int expectedResult = 9;
            int actualResult = huffman.CalculateMinLengthOfCodeword();

            Assert.Equal(expectedResult, actualResult);
        }

    }
}
