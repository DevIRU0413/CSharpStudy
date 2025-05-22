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

        public List<GraphNode<T>> Astart() where T : Vector2
        {
            return null;
        }
    }
}
