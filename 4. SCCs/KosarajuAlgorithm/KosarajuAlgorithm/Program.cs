﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using KosarajuAlgorithm.GraphClasses;

namespace KosarajuAlgorithm
{
    class Program
    {
        //private const int vertexCount = 9;
        private const int vertexCount = 875714;

        static void Main()
        {

            Thread thread = new Thread(GetSCC, 10000000);
            thread.Start();
            thread.Join();

            Console.ReadKey();
        }

        private static void GetSCC()
        {
            Console.WriteLine("Started:{0}", DateTime.Now);
            const string path = @"E:\projects\coursera_algo\4. SCCs\SCC.txt";
            //const string path = @"E:\projects\coursera_algo\4. SCCs\3_3_3_0_0.txt";
            var _initialGraph = ParseInitialFile(path);

            Console.WriteLine("File Parsed at:{0}", DateTime.Now);
            _initialGraph.DFSLoop();

            Console.WriteLine("Finishing times calculated at:{0}", DateTime.Now);
            var _reversedGraph = Reverse(_initialGraph);

            Console.WriteLine("Graph reversed at:{0}", DateTime.Now);
            _reversedGraph.DFSLoop();

            Console.WriteLine("Leaders calculated at:{0}", DateTime.Now);

            Dictionary<int, int> sccs = new Dictionary<int, int>();
            foreach (var vertex in _reversedGraph.Vertices)
            {
                if (sccs.Keys.Contains(vertex.Leader.Name))
                {
                    sccs[vertex.Leader.Name]++;
                }
                else
                {
                    sccs.Add(vertex.Leader.Name, 1);
                }
            }
            var leaders = sccs.Values.OrderByDescending(i => i).Take(5).ToArray();
            var format = string.Join(",", leaders);
            Console.WriteLine("SCCs calculated at:{0}", DateTime.Now);
            Console.WriteLine(format);
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
