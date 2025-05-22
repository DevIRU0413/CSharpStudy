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
                Console.WriteLine(dfsList[i].Data.ToString());
            Console.WriteLine();

            Console.WriteLine("BFS");
            var toVisit = new Queue<GraphNode<string>>();
            toVisit.Enqueue(node0);
            var bfsList = graph.BFS(toVisit);
            for (int i = 0; i < bfsList.Count; i++)
                Console.WriteLine(bfsList[i].Data.ToString());
            Console.WriteLine();

            var dijkstra = graph.Dijkstra(node0, node5);
            var dijkstra2 = graph.Dijkstra(node0, node7);

            Console.WriteLine("Dijkstra");
            foreach (var d in dijkstra)
                Console.WriteLine(d.Data.ToString());

            Console.WriteLine("Dijkstra");
            foreach (var d in dijkstra2)
                Console.WriteLine(d.Data.ToString());


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
            graph3.AddEdgeCycle(nodeA0, nodeA1, Vector2.Distance(nodeA0.Data, nodeA1.Data));
            graph3.AddEdgeCycle(nodeA1, nodeA2, Vector2.Distance(nodeA1.Data, nodeA2.Data));
            graph3.AddEdgeCycle(nodeA0, nodeA4, Vector2.Distance(nodeA0.Data, nodeA4.Data));
            graph3.AddEdgeCycle(nodeA4, nodeA5, Vector2.Distance(nodeA4.Data, nodeA5.Data));
            graph3.AddEdgeCycle(nodeA2, nodeA5, Vector2.Distance(nodeA2.Data, nodeA5.Data));
            graph3.AddEdgeCycle(nodeA0, nodeA3, Vector2.Distance(nodeA0.Data, nodeA3.Data));

            graph3.AddEdgeCycle(nodeA1, nodeA6, Vector2.Distance(nodeA1.Data, nodeA6.Data));
            graph3.AddEdgeCycle(nodeA6, nodeA7, Vector2.Distance(nodeA6.Data, nodeA7.Data));
            graph3.AddEdgeCycle(nodeA2, nodeA7, Vector2.Distance(nodeA2.Data, nodeA7.Data));
            graph3.AddEdgeCycle(nodeA7, nodeA8, Vector2.Distance(nodeA7.Data, nodeA8.Data));
            graph3.AddEdgeCycle(nodeA5, nodeA8, Vector2.Distance(nodeA5.Data, nodeA8.Data));

            graph3.AddEdgeCycle(nodeA3, nodeA9, Vector2.Distance(nodeA3.Data, nodeA9.Data));
            graph3.AddEdgeCycle(nodeA9, nodeA10, Vector2.Distance(nodeA9.Data, nodeA10.Data));
            graph3.AddEdgeCycle(nodeA10, nodeA2, Vector2.Distance(nodeA10.Data, nodeA2.Data));

            graph3.PrintGraphInfo();

            var astarPath = graph3.AStar(nodeA0, nodeA5);
            Console.WriteLine("AStar1");
            foreach (var a in astarPath)
                Console.WriteLine(a.Data.ToString());


            astarPath = graph3.AStar(nodeA0, nodeA10);

            Console.WriteLine("AStar2");
            foreach (var a in astarPath)
                Console.WriteLine(a.Data.ToString());


            astarPath = graph3.AStar(nodeA3, nodeA7);

            Console.WriteLine("AStar3");
            foreach (var a in astarPath)
                Console.WriteLine(a.Data.ToString());


            Graph<string> graph4 = new Graph<string>();

            List<string> stations = new List<string>
            {
                "서울역", "시청", "종각", "종로3가", "종로5가", "동대문",
                "을지로입구", "을지로3가", "을지로4가", "동대문역사문화공원",
                "신당", "상왕십리", "왕십리",
                "약수", "동대입구", "충무로",
                "청구", "신금호", "행당"
            };

            Dictionary<string, List<(string, float)>> stationsList = new()
            {
                // 1호선
                ["서울역"] = new() { ("시청", 1) },
                ["시청"] = new() { ("서울역", 1), ("종각", 1), ("을지로입구", 1) },
                ["종각"] = new() { ("시청", 1), ("종로3가", 1) },
                ["종로3가"] = new() { ("종각", 1), ("종로5가", 1), ("을지로4가", 1), ("충무로", 1) },
                ["종로5가"] = new() { ("종로3가", 1), ("동대문", 1) },
                ["동대문"] = new() { ("종로5가", 1) },

                // 2호선
                ["을지로입구"] = new() { ("시청", 1), ("을지로3가", 1) },
                ["을지로3가"] = new() { ("을지로입구", 1), ("을지로4가", 1), ("충무로", 1) },
                ["을지로4가"] = new() { ("을지로3가", 1), ("동대문역사문화공원", 1), ("종로3가", 1) },
                ["동대문역사문화공원"] = new() { ("을지로4가", 1), ("신당", 1), ("청구", 1) },
                ["신당"] = new() { ("동대문역사문화공원", 1), ("상왕십리", 1) },
                ["상왕십리"] = new() { ("신당", 1), ("왕십리", 1) },
                ["왕십리"] = new() { ("상왕십리", 1), ("행당", 1) },

                // 3호선
                ["약수"] = new() { ("동대입구", 1), ("청구", 1) },
                ["동대입구"] = new() { ("약수", 1), ("충무로", 1) },
                ["충무로"] = new() { ("동대입구", 1), ("을지로3가", 1), ("종로3가", 1) },

                // 5호선
                ["청구"] = new() { ("약수", 1), ("동대문역사문화공원", 1), ("신금호", 1) },
                ["신금호"] = new() { ("청구", 1), ("행당", 1) },
                ["행당"] = new() { ("신금호", 1), ("왕십리", 1) }
            };

            // 노드 추가
            foreach (var s in stationsList)
            {
                string key = s.Key;
                graph4.AddNode(key);
            }

            // 노드간 간선 추가
            foreach (var s in stationsList)
            {
                string key = s.Key;
                foreach(var v in s.Value)
                    graph4.AddEdgeCycle(graph4.FindValue(key), graph4.FindValue(v.Item1), v.Item2);
            }

            graph4.PrintGraphInfo();
            var station = graph4.Dijkstra(graph4.FindValue("서울역"), graph4.FindValue("신금호"));

            Console.WriteLine("\n\nStation Dijkstra\n");
            foreach (var d in station)
                Console.Write(d.Data.ToString() + ", ");
            Console.WriteLine("\n");
            Console.WriteLine($"출발치 > {station[0].Data}, 도착치 > {station[station.Count - 1].Data}");
            Console.WriteLine($"출발지로 부터 총 {station.Count - 1}개의 정거장을 거쳐야되며, {(station.Count - 1) * 3}분 소요됩니다.");
        }
    }
}
