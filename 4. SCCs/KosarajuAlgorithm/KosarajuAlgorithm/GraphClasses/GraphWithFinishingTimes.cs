namespace KosarajuAlgorithm.GraphClasses
{
    public class GraphWithFinishingTimes : Graph
    {
        private int _finishingTime;

        protected override void DFS(Vertex currentVertex)
        {
            base.DFS(currentVertex);
            _finishingTime++;
            currentVertex.FinishingTime = _finishingTime;
        }
    }
}