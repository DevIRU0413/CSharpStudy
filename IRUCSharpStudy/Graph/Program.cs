namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();
            GraphNode<string> a = graph.AddNode("A");
            GraphNode<string> b = graph.AddNode("B");
            GraphNode<string> c = graph.AddNode("C");
            GraphNode<string> d = graph.AddNode("D");

            graph.AddEdge(a, c);

            graph.AddEdgeCycle(a, b);
            graph.AddEdgeCycle(c, d);

            graph.PrintGraphInfo();
        }
    }
}
