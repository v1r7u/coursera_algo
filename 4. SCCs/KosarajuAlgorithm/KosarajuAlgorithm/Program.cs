using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KosarajuAlgorithm.GraphClasses;

namespace KosarajuAlgorithm
{
    class Program
    {
        const int vertexCount = 875714;

        static void Main(string[] args)
        {
            const string path = @"E:\projects\coursera_algo\4. SCCs\SCC.txt";
            //const string path = @"E:\projects\coursera_algo\4. SCCs\3_3_3_0_0.txt";
            var _initialGraph = ParseInitialFile(path);
            var _reversedGraph = GetReversedGraph(_initialGraph);

            _reversedGraph.DFSLoop();
            SetFinishingTimes(_initialGraph, _reversedGraph);

            _initialGraph.DFSLoop();
            foreach (var vertex in _initialGraph.Vertices)
            {
                Console.WriteLine("Vertex: {0}, Leader: {1}, Finishing time: {2}", vertex.Name, vertex.Leader.Name, vertex.FinishingTime);
            }

            Console.WriteLine(_initialGraph.GetLeaders());
            Console.ReadKey();
        }

        private static GraphWithLeader ParseInitialFile(string path)
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

                    var vertex1 = vertices[split[0] - 1];
                    var vertex2 = vertices[split[1] - 1];
                    var edge = new Edge(vertex1, vertex2);
                    vertex1.AddEdge(edge);
                    edges.Add(edge);
                    line = sr.ReadLine();
                }
            }

            return new GraphWithLeader
            {
                Edges = edges,
                Vertices = vertices.OrderBy(i=> i.Name).ToList()
            };
        }

        private static GraphWithFinishingTimes GetReversedGraph(Graph initialGraph)
        {
            var reversedGraph = new GraphWithFinishingTimes
            {
                Edges = new List<Edge>()
            };
            var vertices = new Vertex[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                vertices[i] = new Vertex(i + 1);
            }
            foreach (var edge in initialGraph.Edges)
            {
                var vertex1 = vertices[edge.Vertex1.Name - 1];// reversedGraph.Vertices.First(i => i.Name == edge.Vertex1.Name);
                var vertex2 = vertices[edge.Vertex2.Name - 1];// reversedGraph.Vertices.First(i => i.Name == edge.Vertex2.Name);

                var newEdge = new Edge(vertex2, vertex1);
                vertex2.Edges.Add(newEdge);
                reversedGraph.Edges.Add(newEdge);
            }

            reversedGraph.Vertices = vertices.ToList();
            return reversedGraph;
        }

        private static void SetFinishingTimes(Graph initialGraph, Graph reversedGraph)
        {
            foreach (var vertex in reversedGraph.Vertices)
            {
                var first = initialGraph.Vertices.First(i => i.Name == vertex.Name);
                first.FinishingTime = vertex.FinishingTime;
            }
            initialGraph.Vertices = initialGraph.Vertices.OrderBy(i => i.FinishingTime).ToList();
        }
    }
}
