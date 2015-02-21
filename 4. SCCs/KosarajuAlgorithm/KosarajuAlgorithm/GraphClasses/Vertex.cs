namespace KosarajuAlgorithm.GraphClasses
{
    public class Vertex : VertexBase
    {
        public Vertex(){}

        public Vertex(int name) : base(name)
        {
        }

        public int FinishingTime;
        public bool IsExplored;
        public Vertex Leader;
    }
}