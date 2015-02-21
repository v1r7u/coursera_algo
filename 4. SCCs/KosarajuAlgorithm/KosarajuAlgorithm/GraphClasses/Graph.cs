namespace KosarajuAlgorithm.GraphClasses
{
    public class Graph
    {
        private int _finishingTime;
        private Vertex _currentLeader;

        public Edge[] Edges;
        public Vertex[] Vertices;

        public void DFSLoop()
        {
            for (int i = Vertices.Length - 1; i >= 0; i--)
            {
                if (!Vertices[i].IsExplored)
                {
                    _currentLeader = Vertices[i];
                    DFS(Vertices[i]);
                }
            }
        }

        private void DFS(Vertex currentVertex)
        {
            currentVertex.IsExplored = true;
            currentVertex.Leader = _currentLeader;

            var count = currentVertex.Edges.Count;
            for(int i=0; i< count; i++)
            {
                if (!currentVertex.Edges[i].Vertex2.IsExplored)
                    DFS(currentVertex.Edges[i].Vertex2);
            }
            _finishingTime++;
            currentVertex.FinishingTime = _finishingTime;
        }
    }
}