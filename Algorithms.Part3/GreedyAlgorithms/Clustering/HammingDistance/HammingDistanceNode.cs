namespace Algorithms.Part3.GreedyAlgorithms.Clustering.HammingDistance
{
    internal class HammingDistanceNode
    {
        public int BinaryValue { get; private set; }
        public int ID { get; private set; }
        public HammingDistanceNode(string binaryString, int id)
        {
            binaryString = binaryString.Replace(" ", "");
            BinaryValue = Convert.ToInt32(binaryString, 2);
            ID = id;
        }
    }
}