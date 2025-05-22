using System.Numerics;

namespace Graph
{
    // 그래프
    // 정점의 모음과 이 정점을 잇는 간산의 모음의 결합
    // 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가진다.
    // 간산의 방향성에 따라 단방향 그래프, 양방향 그래프가 있다.
    // 간선의 가중치에 따라 연결 그래프, 가중치 그래픔가 있다.

    public class Graph<T>
    {
        private List<GraphNode<T>> _nodes = new List<GraphNode<T>>();
        public GraphNode<T> AddNode(T value)
        {
            GraphNode<T> node = new(value);
            _nodes.Add(node);
            return node;
        }

        // 단방향 연결
        public void AddEdge(GraphNode<T> from, GraphNode<T> to, float weight = 0.0f)
        {
            from.AddEdge(to, weight);
        }

        // 양방향 연결
        public void AddEdgeCycle(GraphNode<T> from, GraphNode<T> to, float weight = 0.0f)
        {
            if (!from.IsConnet(to))
                from.AddEdge(to, weight);

            if (!to.IsConnet(from))
                to.AddEdge(from, weight);
        }

        // 간선 연결 제거
        public void RemoveNode(GraphNode<T> node)
        {
            foreach (var n in _nodes)
            {
                n.RemoveEdge(node);
            }

            _nodes.Remove(node);
        }

        public GraphNode<T> FindValue(T value)
        {
            foreach(var n in _nodes)
            {
                if (value.Equals(n.Data))
                    return n;
            }
            return null;
        }

        // 구성 요소 출력
        public void PrintGraphInfo()
        {
            Console.WriteLine("그래프");
            foreach (var node in _nodes)
            {
                node.PrintNeighborNodes();
            }
        }

        // 깊이 우선 탐색
        public List<GraphNode<T>> DFS(GraphNode<T> node, List<GraphNode<T>> visited = null)
        {
            var findNodes = node.NeighborNodes;

            if (visited == null)
                visited = new List<GraphNode<T>>();

            visited.Add(node);
            foreach (var findNode in findNodes)
            {
                if (!visited.Contains(findNode.Key))
                    DFS(findNode.Key, visited);
            }

            return visited;
        }

        // 넓이 우선 탐색
        public List<GraphNode<T>> BFS(Queue<GraphNode<T>> toVisit, List<GraphNode<T>> visited = null)
        {
            if (toVisit == null || toVisit.Count == 0)
                return visited;

            var visitNode = toVisit.Dequeue();

            if (visited == null)
                visited = new List<GraphNode<T>>();
            visited.Add(visitNode);

            var findNodes = visitNode.NeighborNodes;
            foreach (var findNode in findNodes)
            {
                if (!toVisit.Contains(findNode.Key) && !visited.Contains(findNode.Key))
                    toVisit.Enqueue(findNode.Key);
            }

            BFS(toVisit, visited);
            return visited;
        }

        // 다익스트라 알고리즘 길 찾기
        public List<GraphNode<T>> Dijkstra(GraphNode<T> startNode, GraphNode<T> endNode)
        {
            if (_nodes == null || _nodes.Count == 0 || startNode == null || endNode == null)
                return null;

            Dictionary<GraphNode<T>, float> dist = new();
            Dictionary<GraphNode<T>, GraphNode<T>> prev = new();
            List<GraphNode<T>> visited = new();

            foreach (var node in _nodes)
            {
                dist[node] = float.MaxValue;
                prev[node] = null;
            }
            dist[startNode] = 0f;

            var pq = new PriorityQueue<GraphNode<T>, float>();
            pq.Enqueue(startNode, 0f);

            while (pq.Count > 0)
            {
                var current = pq.Dequeue();

                if (visited.Contains(current))
                    continue;
                visited.Add(current);

                if (current == endNode)
                    break;

                foreach (var neighborPair in current.NeighborNodes)
                {
                    var neighbor = neighborPair.Key;
                    float weight = neighborPair.Value;

                    float newDist = dist[current] + weight;

                    if (newDist < dist[neighbor])
                    {
                        dist[neighbor] = newDist;
                        prev[neighbor] = current;
                        pq.Enqueue(neighbor, newDist);
                    }
                }
            }

            // 경로 복원
            visited.Clear(); // 재사용
            var trace = endNode;

            if (dist[trace] == float.MaxValue)
                return null; // 경로 없음

            while (trace != null)
            {
                visited.Add(trace);
                trace = prev[trace];
            }

            visited.Reverse();
            return visited;
        }

        // A* 알고리즘 길찾기
        public List<GraphNode<Vector2>> AStar(GraphNode<Vector2> start, GraphNode<Vector2> goal)
        {
            var openSet = new PriorityQueue<GraphNode<Vector2>, float>();
            var cameFrom = new Dictionary<GraphNode<Vector2>, GraphNode<Vector2>>();

            var gScore = new Dictionary<GraphNode<Vector2>, float>();
            var fScore = new Dictionary<GraphNode<Vector2>, float>();

            gScore[start] = 0f;
            fScore[start] = Heuristic(start.Data, goal.Data);
            openSet.Enqueue(start, fScore[start]);

            while (openSet.Count > 0)
            {
                var current = openSet.Dequeue();

                if (current == goal)
                    return ReconstructPath(cameFrom, current);

                foreach (var neighborPair in current.NeighborNodes)
                {
                    var neighbor = neighborPair.Key;
                    float weight = neighborPair.Value;

                    float tentativeG = gScore[current] + weight;

                    if (!gScore.ContainsKey(neighbor) || tentativeG < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeG;
                        fScore[neighbor] = tentativeG + Heuristic(neighbor.Data, goal.Data);

                        openSet.Enqueue(neighbor, fScore[neighbor]);
                    }
                }
            }

            return null;
        }

        private float Heuristic(Vector2 a, Vector2 b)
        {
            return Vector2.Distance(a, b);
        }
        private List<GraphNode<Vector2>> ReconstructPath(Dictionary<GraphNode<Vector2>, GraphNode<Vector2>> cameFrom, GraphNode<Vector2> current)
        {
            List<GraphNode<Vector2>> path = new() { current };

            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Add(current);
            }

            path.Reverse();
            return path;
        }
    }
}
