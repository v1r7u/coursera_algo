using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KargerMinCut
{
    class Program
    {
        static void Main()
        {
            const string path = @"E:\projects\coursera\3. MinCut\testCase1.txt";
            const string path2 = @"E:\projects\coursera\3. MinCut\kargerMinCut.txt";
            Graph graph = ParseInitialFile(path);

            int minimumCut = graph.GetMinimumCut();

            Console.WriteLine(minimumCut);
            Console.ReadKey();
        }

        private static Graph ParseInitialFile(string path)
        {
            var vertices = new List<Vertex>();
            var edges = new List<Edge>();

            using (var fs = File.Open(path, FileMode.Open))
            using(var sr = new StreamReader(fs))
            {
                var strings = sr.ReadToEnd().Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strings.Length; i++)
                {
                    vertices.Add(new Vertex());
                }
                
                for (int i = 0; i < strings.Length; i++)
                {
                    var elements = strings[i].Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);

                    var currentName = int.Parse(elements[0]);
                    vertices[i].Name = currentName;

                    for (int j = 1; j < elements.Length; j++)
                    {
                        var edge = new Edge(vertices[currentName - 1], vertices[int.Parse(elements[j]) - 1]);
                        edges.Add(edge);
                        vertices[i].AddEdge(edge);
                    }
                }
            }

            return new Graph
            {
                Edges = edges.Distinct().ToList(),
                Vertices = vertices
            };
        }
    }
}
