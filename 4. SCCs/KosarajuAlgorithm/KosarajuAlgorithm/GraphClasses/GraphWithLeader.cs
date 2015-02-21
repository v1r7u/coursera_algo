using System.Collections.Generic;
using System.Linq;

namespace KosarajuAlgorithm.GraphClasses
{
    public class GraphWithLeader : Graph
    {
        private Vertex _currentLeader;
        private readonly Dictionary<Vertex, int> _scc = new Dictionary<Vertex, int>();

        public string GetLeaders()
        {
            return string.Join(",", _scc.Values.OrderByDescending(i => i));
        }

        protected override void SetCurrentLeader(Vertex vertex)
        {
            _currentLeader = vertex;
        }

        protected override void SetLeader(Vertex currentVertex)
        {
            currentVertex.Leader = _currentLeader;
            AddToLeaderBoard(_currentLeader);
        }

        private void AddToLeaderBoard(Vertex vertex)
        {
            if (_scc.FirstOrDefault(i=> i.Key == vertex).Value == 0)
            {
                _scc.Add(vertex, 1);
            }
            else
            {
                _scc[vertex]++;
            }
        }
    }
}