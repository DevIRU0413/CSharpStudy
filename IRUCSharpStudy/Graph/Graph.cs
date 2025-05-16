namespace Graph
{
    internal class Graph<T>
    {
        private List<GraphNode<T>> _nodes = new List<GraphNode<T>>();
        public GraphNode<T> AddNode(T value)
        {
            GraphNode<T> node = new(value);
            _nodes.Add(node);
            return node;
        }

        public void AddEdge(GraphNode<T> from, GraphNode<T> to)
        {
            from.NeighborNodes.Add(to);
        }

        public void AddEdgeCycle(GraphNode<T> from, GraphNode<T> to)
        {
            from.NeighborNodes.Add(to);
            to.NeighborNodes.Add(from);
        }
        public void RemoveNode(GraphNode<T> node)
        {
            foreach (var n in _nodes)
            {
                n.RemoveEdge(node);
            }

            _nodes.Remove(node);
        }
        public void PrintGraphInfo()
        {
            Console.WriteLine("그래프");
            foreach (var node in _nodes)
            {
                node.PrintNeighborNodes();
            }
        }
    }
}
