using Algorithms.Part1.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.FileIO
{
    public class FileManager
    {
        public int[] ReadFileIntoIntArray(string path)
        {
            var readString = File.ReadAllLines(path);

            var output = new int[readString.Length];

            for (int i = 0; i < readString.Length; i++)
            {
                output[i] = Convert.ToInt32(readString[i]);
            }

            return output;
        }

        public GraphRepresentation ReadGraph(string path)
        {
            string[] readString = File.ReadAllLines(path);

            GraphRepresentation graph = new GraphRepresentation(readString.Length);

            for (int rowIndex = 0; rowIndex < readString.Length; rowIndex++)
            {
                int[] adjacentVertices = GetAdjacentVertices(readString[rowIndex]);

                int vertexIndex = rowIndex;

                graph.ConnectVertices(vertexIndex, adjacentVertices);
            }

            return graph;
        }

        private int[] GetAdjacentVertices(string vertexInfo)
        {
            string[] parsedInfo = vertexInfo.Split(new char[] { ' ', '\t' },StringSplitOptions.RemoveEmptyEntries);

            int[] adjacentVertices = new int[parsedInfo.Length - 1];

            int adjacentVertexIndex = 0;

            for (int index = 1; index < parsedInfo.Length; index++)
            {
                adjacentVertices[adjacentVertexIndex] = int.Parse(parsedInfo[index]) - 1;
                adjacentVertexIndex++;
            }

            return adjacentVertices;
        }
    }
}
