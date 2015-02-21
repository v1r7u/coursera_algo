using System.Collections.Generic;

namespace KosarajuAlgorithm.GraphClasses
{
    public class Graph
    {
        public List<Edge> Edges { get; set; }
        public List<Vertex> Vertices { get; set; }

        public void DFSLoop()
        {
            for (int i = Vertices.Count - 1; i >= 0; i--)
            {
                var currentVertex = Vertices[i];
                if (!currentVertex.IsExplored)
                {
                    SetCurrentLeader(currentVertex);
                    DFS(currentVertex);
                }
            }
        }

        protected virtual void SetCurrentLeader(Vertex vertex)
        {
        }

        protected virtual void DFS(Vertex currentVertex)
        {
            currentVertex.IsExplored = true;
            SetLeader(currentVertex);
            foreach (var edge in currentVertex.Edges)
            {
                if(!edge.Vertex2.IsExplored)
                    DFS(edge.Vertex2);
            }
        }

        protected virtual void SetLeader(Vertex currentVertex)
        {
        }
    }
}