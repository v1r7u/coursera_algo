using System.Collections.Generic;

namespace KosarajuAlgorithm.GraphClasses
{
    public sealed class Vertex
    {
        public Vertex()
        {
            Edges = new List<Edge>();
        }

        public Vertex(int name)
        {
            Name = name;
            Edges = new List<Edge>();
        }

        public Vertex(int name, int finishingTime)
        {
            Name = name;
            Edges = new List<Edge>();
            FinishingTime = finishingTime;
        }

        public readonly List<Edge> Edges;
        public readonly int Name;

        public int FinishingTime;
        public bool IsExplored;
        public Vertex Leader;

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