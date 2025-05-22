namespace Graph
{
    public class GraphNode<T>
    {
        public T Value;
        public Dictionary<GraphNode<T>, float> NeighborNodes { get; private set; } = new();

        public GraphNode(T value)
        {
            Value = value;
        }

        public void PrintNeighborNodes()
        {
            Console.WriteLine();
            Console.WriteLine($"[{Value}]");
            foreach (var neighbor in NeighborNodes)
                Console.WriteLine($" └─ node {neighbor.Key.Value}, weight {neighbor.Value}");
        }

        public void AddEdge(GraphNode<T> node, float weight = 0.0f)
        {
            NeighborNodes.Add(node, weight);
        }

        public void RemoveEdge(GraphNode<T> node)
        {
            NeighborNodes.Remove(node);
        }

        public bool IsConnet(GraphNode<T> node)
        {
            return NeighborNodes.ContainsKey(node);
        }
    }
}