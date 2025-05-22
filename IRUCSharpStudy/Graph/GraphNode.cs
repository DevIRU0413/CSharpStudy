namespace Graph
{
    public class GraphNode<T>
    {
        public T Data;
        public Dictionary<GraphNode<T>, float> NeighborNodes { get; private set; } = new();

        public GraphNode(T value)
        {
            Data = value;
        }

        public void PrintNeighborNodes()
        {
            Console.WriteLine();
            Console.WriteLine($"[{Data}]");
            foreach (var neighbor in NeighborNodes)
                Console.WriteLine($" └─ node {neighbor.Key.Data}, weight {neighbor.Value}");
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