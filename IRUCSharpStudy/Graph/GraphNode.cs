namespace Graph
{
    internal class GraphNode<T>
    {
        public T Value;
        public List<GraphNode<T>> NeighborNodes { get; } = new();

        public GraphNode(T value)
        {
            Value = value;
        }

        public void PrintNeighborNodes()
        {
            Console.WriteLine();
            Console.WriteLine($"[{Value}]");
            foreach (var neighbor in NeighborNodes)
            {
                Console.WriteLine($" └─ {neighbor.Value}");
            }
        }

        public void AddEdge(GraphNode<T> node)
        {
            NeighborNodes.Add(node);
        }

        public void RemoveEdge(GraphNode<T> node)
        {
            NeighborNodes.Remove(node);
        }
    }
}