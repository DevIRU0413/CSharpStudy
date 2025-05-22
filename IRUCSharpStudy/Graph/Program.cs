using System.Numerics;

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



            Graph<Vector2> graph3 = new Graph<Vector2>();

            GraphNode<Vector2> nodeA0 = graph3.AddNode(new Vector2(0, 1));
            GraphNode<Vector2> nodeA1 = graph3.AddNode(new Vector2(2, 1));
            GraphNode<Vector2> nodeA2 = graph3.AddNode(new Vector2(4, 2));
            GraphNode<Vector2> nodeA3 = graph3.AddNode(new Vector2(0, 10));
            GraphNode<Vector2> nodeA4 = graph3.AddNode(new Vector2(1, 4));
            GraphNode<Vector2> nodeA5 = graph3.AddNode(new Vector2(5, 5));
            GraphNode<Vector2> nodeA6 = graph3.AddNode(new Vector2(3, 0));
            GraphNode<Vector2> nodeA7 = graph3.AddNode(new Vector2(6, 1));
            GraphNode<Vector2> nodeA8 = graph3.AddNode(new Vector2(6, 6));
            GraphNode<Vector2> nodeA9 = graph3.AddNode(new Vector2(2, 8));
            GraphNode<Vector2> nodeA10 = graph3.AddNode(new Vector2(4, 10));


            // 노드 간 연결 (양방향 연결로 가정)
            graph3.AddEdgeCycle(nodeA0, nodeA1, Vector2.Distance(nodeA0.Value, nodeA1.Value));
            graph3.AddEdgeCycle(nodeA1, nodeA2, Vector2.Distance(nodeA1.Value, nodeA2.Value));
            graph3.AddEdgeCycle(nodeA0, nodeA4, Vector2.Distance(nodeA0.Value, nodeA4.Value));
            graph3.AddEdgeCycle(nodeA4, nodeA5, Vector2.Distance(nodeA4.Value, nodeA5.Value));
            graph3.AddEdgeCycle(nodeA2, nodeA5, Vector2.Distance(nodeA2.Value, nodeA5.Value));
            graph3.AddEdgeCycle(nodeA0, nodeA3, Vector2.Distance(nodeA0.Value, nodeA3.Value));
                          
            graph3.AddEdgeCycle(nodeA1, nodeA6, Vector2.Distance(nodeA1.Value, nodeA6.Value));
            graph3.AddEdgeCycle(nodeA6, nodeA7, Vector2.Distance(nodeA6.Value, nodeA7.Value));
            graph3.AddEdgeCycle(nodeA2, nodeA7, Vector2.Distance(nodeA2.Value, nodeA7.Value));
            graph3.AddEdgeCycle(nodeA7, nodeA8, Vector2.Distance(nodeA7.Value, nodeA8.Value));
            graph3.AddEdgeCycle(nodeA5, nodeA8, Vector2.Distance(nodeA5.Value, nodeA8.Value));
                          
            graph3.AddEdgeCycle(nodeA3, nodeA9, Vector2.Distance(nodeA3.Value, nodeA9.Value));
            graph3.AddEdgeCycle(nodeA9, nodeA10, Vector2.Distance(nodeA9.Value, nodeA10.Value));
            graph3.AddEdgeCycle(nodeA10, nodeA2, Vector2.Distance(nodeA10.Value, nodeA2.Value));


            var astarPath = graph3.AStar(nodeA0, nodeA5);
            
            Console.WriteLine("AStar1");
            foreach (var a in astarPath)
                Console.WriteLine(a.Value.ToString());


            astarPath = graph3.AStar(nodeA0, nodeA10);

            Console.WriteLine("AStar2");
            foreach (var a in astarPath)
                Console.WriteLine(a.Value.ToString());


            astarPath = graph3.AStar(nodeA3, nodeA7);

            Console.WriteLine("AStar3");
            foreach (var a in astarPath)
                Console.WriteLine(a.Value.ToString());
        }
    }
}
