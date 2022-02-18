using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms
{
    public class DirectedGraphHelperMethods
    {
        public Dictionary<int, List<int>> ReverseVertexToConnectedVertexIDs(Dictionary<int, List<int>> vertexIdsToConnectedVertexIds)
        {
            Dictionary<int, List<int>> reversedVertexToConnectedVertexIDs = new Dictionary<int, List<int>>();

            foreach (var vertexIdToConnectedIds in vertexIdsToConnectedVertexIds)
            {
                int vertexId = vertexIdToConnectedIds.Key;
                List<int> connectedVertices = vertexIdToConnectedIds.Value;

                foreach (var connectedVertex in connectedVertices)
                {
                    ConnectVertex1ToVertex2(connectedVertex, vertexId, reversedVertexToConnectedVertexIDs);
                }
            }

            return reversedVertexToConnectedVertexIDs;
        }

        static private object syncObj=new object();
        

        private void ConnectVertex1ToVertex2(int vertex1, int vertex2, Dictionary<int, List<int>> reversedVertexToConnectedVertexIDs)
        {
            if (reversedVertexToConnectedVertexIDs.TryGetValue(vertex1, out List<int> connectedVertices))
            {
                connectedVertices.Add(vertex2);
            }
            else
            {
                connectedVertices = new List<int>();
                reversedVertexToConnectedVertexIDs.Add(vertex1, connectedVertices);
                connectedVertices.Add(vertex2);
            }
        }


    }
}
