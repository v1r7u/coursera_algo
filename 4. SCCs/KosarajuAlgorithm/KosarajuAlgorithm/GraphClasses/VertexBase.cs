using System.Collections.Generic;

namespace KosarajuAlgorithm.GraphClasses
{
    public abstract class VertexBase
    {
        protected VertexBase()
        {
            Edges = new List<Edge>();
        }

        protected VertexBase(int name)
        {
            Name = name;
            Edges = new List<Edge>();
        }

        public List<Edge> Edges { get; private set; } 
        public int Name { get; set; }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}