using System;
using System.Collections.Generic;

namespace KargerMinCut
{
    public class Graph
    {
        private readonly Random _random = new Random();

        public List<Edge> Edges { get; set; }
        public List<Vertex> Vertices { get; set; }

        public int GetMinimumCut()
        {
            if (Vertices.Count <= 2)
                return Edges.Count;

            Edge randomEdge = GetRandomEdge(Edges.Count);

            Edges.Remove(randomEdge);

            Vertices.Remove(randomEdge.Vertex1);
            var name = randomEdge.Vertex1.Name;

            for (int index = 0; index < Edges.Count;)
            {
                var edge = Edges[index];

                if (edge.Vertex1.Name == name)
                {
                    edge.Vertex1 = randomEdge.Vertex2;
                }
                else if (edge.Vertex2.Name == name)
                {
                    edge.Vertex2 = randomEdge.Vertex2;
                }

                if (edge.Vertex1.Name == edge.Vertex2.Name)
                {
                    Edges.Remove(edge);
                }
                else
                {
                    index++;
                }
            }

            return GetMinimumCut();
        }

        private Edge GetRandomEdge(int max)
        {
            return Edges[_random.Next(0, max)];
        }
    }
}