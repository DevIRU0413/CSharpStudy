namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();

            GraphNode<string> node0 = graph.AddNode("0");
            GraphNode<string> node1 = graph.AddNode("1");
            GraphNode<string> node2 = graph.AddNode("2");
            GraphNode<string> node3 = graph.AddNode("3");
            GraphNode<string> node4 = graph.AddNode("4");
            GraphNode<string> node5 = graph.AddNode("5");
            GraphNode<string> node6 = graph.AddNode("6");
            GraphNode<string> node7 = graph.AddNode("7");

            graph.AddEdgeCycle(node0, node3, 2);
            graph.AddEdgeCycle(node0, node4, 4);

            graph.AddEdgeCycle(node1, node3, 8);
            graph.AddEdgeCycle(node1, node5, 1);
            graph.AddEdgeCycle(node1, node2, 3);

            graph.AddEdgeCycle(node2, node1, 5);
            graph.AddEdgeCycle(node2, node5, 6);
            graph.AddEdgeCycle(node2, node6, 7);
            graph.AddEdgeCycle(node2, node4, 9);

            graph.AddEdgeCycle(node3, node0, 2);
            graph.AddEdgeCycle(node3, node1, 5);
            graph.AddEdgeCycle(node3, node7, 8);

            graph.AddEdgeCycle(node4, node0, 1);
            graph.AddEdgeCycle(node4, node2, 4);

            graph.AddEdgeCycle(node5, node1, 7);
            graph.AddEdgeCycle(node5, node2, 2);
            graph.AddEdgeCycle(node5, node7, 3);

            graph.AddEdgeCycle(node6, node2, 5);

            graph.AddEdgeCycle(node7, node3, 6);
            graph.AddEdgeCycle(node7, node5, 8);

            graph.PrintGraphInfo();

            Console.WriteLine("DFS");
            var dfsList = graph.DFS(node0);
            for (int i = 0; i < dfsList.Count; i++)
                Console.WriteLine(dfsList[i].Value.ToString());
            Console.WriteLine();

            Console.WriteLine("BFS");
            var toVisit = new Queue<GraphNode<string>>();
            toVisit.Enqueue(node0);
            var bfsList = graph.BFS(toVisit);
            for (int i = 0; i < bfsList.Count; i++)
                Console.WriteLine(bfsList[i].Value.ToString());
            Console.WriteLine();

            var dijkstra = graph.Dijkstra(node0, node5);
            var dijkstra2 = graph.Dijkstra(node0, node7);
            
            Console.WriteLine("Dijkstra");
            foreach (var d in dijkstra)
                Console.WriteLine(d.Value.ToString());

            Console.WriteLine("Dijkstra");
            foreach (var d in dijkstra2)
                Console.WriteLine(d.Value.ToString());

            // <인접행령 그래프>
            // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
            // 2차원 배열을 [출발정점, 도착정점] 으로 표현
            // 장점: 인접여부 접근이 빠름
            // 단점: 메모리 사용량이 많음

            // bool로 연결 여부만 판단할수 있게 쓸수 있음
            bool[,] graph2 = new bool[8, 8];

            graph2[0, 3] = true;
            graph2[0, 4] = true;

            graph2[1, 3] = true;
            graph2[1, 5] = true;
            graph2[1, 2] = true;

            graph2[2, 1] = true;
            graph2[2, 5] = true;
            graph2[2, 6] = true;
            graph2[2, 4] = true;

            graph2[3, 0] = true;
            graph2[3, 1] = true;
            graph2[3, 7] = true;

            graph2[4, 0] = true;
            graph2[4, 2] = true;

            graph2[5, 1] = true;
            graph2[5, 2] = true;
            graph2[5, 7] = true;

            graph2[6, 2] = true;

            graph2[7, 3] = true;
            graph2[7, 5] = true;

            // int로 가중치를 주는 형식으로 사용할 수 있음
            int[,] graph3 = new int[8, 8];

            graph3[0, 1] = 5;
            graph3[1, 3] = 6;
        }
    }
}
