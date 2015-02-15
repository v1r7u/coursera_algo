using System.Collections.Generic;
using System.Linq;

namespace KargerMinCut
{
    public class Vertex
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

        public int Name { get; set; }
        public List<Edge> Edges { get; private set; }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public void RemoveEdge(Edge edge)
        {
            Edges.Remove(edge);
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public void ReplaceEdge(Edge oldEdge, Edge newEdge)
        {
            Edges.Remove(oldEdge);
            Edges.Add(newEdge);
        }
    }
}
