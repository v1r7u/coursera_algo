namespace KosarajuAlgorithm.GraphClasses
{
    public sealed class Edge
    {
        public Edge(Vertex vertex1, Vertex vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }

        public readonly Vertex Vertex1;
        public readonly Vertex Vertex2;

        public override string ToString()
        {
            return string.Format("{0} - {1}", Vertex1.Name, Vertex2.Name);
        }
    }
}