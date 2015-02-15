using System;
using System.Collections.Generic;
using System.Linq;

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
            
            // todo: remove only if the one same egde
            Vertices.Remove(randomEdge.Vertex1);

            var count = Edges.Count;
            for (int i = 0; i < count; i++)
            {
                var edge = Edges[i];
                if (edge.Vertex1.Name == randomEdge.Vertex1.Name)
                {
                    var newEdge = new Edge(randomEdge.Vertex2, edge.Vertex2);
                    randomEdge.Vertex2.ReplaceEdge(edge, newEdge);
                    Edges.Remove(edge);
                    Edges.Add(newEdge);
                    //edge.Vertex1 = randomEdge.Vertex2;
                    // todo: add new adge to randomEdge.Vertex2
                }
                else if (edge.Vertex2.Name == randomEdge.Vertex1.Name)
                {
                    var newEdge = new Edge(edge.Vertex1, randomEdge.Vertex2);
                    randomEdge.Vertex2.ReplaceEdge(edge, newEdge);
                    Edges.Remove(edge);
                    Edges.Add(newEdge);
                    //edge.Vertex2 = randomEdge.Vertex2;
                    // todo: add new adge to randomEdge.Vertex2
                }
            }
            Edges = Edges.OrderBy(i=> i.Vertex1.Name).ToList();

            return GetMinimumCut();
        }


        private Edge GetRandomEdge(int max)
        {
            return Edges[_random.Next(0, max)];
        }
    }
}