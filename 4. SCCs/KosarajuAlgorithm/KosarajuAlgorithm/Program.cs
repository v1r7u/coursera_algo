using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KosarajuAlgorithm.GraphClasses;

namespace KosarajuAlgorithm
{
    class Program
    {
        //private const int vertexCount = 9;
        private const int vertexCount = 875714;

        static void Main(string[] args)
        {
            var graph = GraphWithLeader();

            graph.DFSLoop();

            Console.ReadKey();
        }

        private static Graph GraphWithLeader()
        {
            const string path = @"E:\projects\coursera_algo\4. SCCs\SCC.txt";
            //const string path = @"E:\projects\coursera_algo\4. SCCs\3_3_3_0_0.txt";
            var _initialGraph = ParseInitialFile(path);

            _initialGraph.DFSLoop();
            
            var _reversedGraph = Reverse(_initialGraph);

            return _reversedGraph;
        }

        private static Graph ParseInitialFile(string path)
        {
            var vertices = new Vertex[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                vertices[i] = new Vertex(i + 1);
            }
            var edges = new List<Edge>();

            using (var fs = File.Open(path, FileMode.Open))
            using (var sr = new StreamReader(fs))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    var split = line
                        .Split(new []{" "},StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    var vertex1 = vertices[split[1] - 1];
                    var vertex2 = vertices[split[0] - 1];
                    var edge = new Edge(vertex1, vertex2);
                    vertex1.AddEdge(edge);
                    edges.Add(edge);
                    line = sr.ReadLine();
                }
            }

            return new Graph
            {
                Edges = edges.ToArray(),
                Vertices = vertices
            };
        }

        private static Graph Reverse(Graph initialGraph)
        {
            var edges = new List<Edge>();
            var vertices = new Vertex[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                vertices[i] = new Vertex(i + 1,initialGraph.Vertices[i].FinishingTime);
            }
            foreach (var edge in initialGraph.Edges)
            {
                var vertex1 = vertices[edge.Vertex1.Name - 1];// reversedGraph.Vertices.First(i => i.Name == edge.Vertex1.Name);
                var vertex2 = vertices[edge.Vertex2.Name - 1];// reversedGraph.Vertices.First(i => i.Name == edge.Vertex2.Name);

                var newEdge = new Edge(vertex2, vertex1);
                vertex2.Edges.Add(newEdge);
                edges.Add(newEdge);
            }

            return new Graph
            {
                Vertices = vertices.OrderBy(i=> i.FinishingTime).ToArray(),
                Edges = edges.ToArray()
            };
        }
    }
}
