class Graph
{
    List<(int cost,int to)>[] adjencyList;
    int size;
    bool[] visited;
    int[] distance;
    priorityQueue<int> pq = new priorityQueue<int>();
    public Graph(int size)
    {
        if (size < 1)
            throw new Exception("Can't create the graph");
        this.size = size;
        visited = new bool[size];
        distance = new int[size];
        adjencyList = new List<(int cost, int to)>[size];
        for (int i = 0; i < size; i++)
        {
            adjencyList[i] = new List<(int cost, int to)>();
        }
        for (int i = 0; i < distance.Length; i++)
        {
            distance[i] = int.MaxValue;
        }
    }

    public void AddEdge(int from, int to,int cost)
    {
        adjencyList[from].Add((cost,to));
    }

    public void Dijkstra(int start)
    {
        distance[start] = 0;
        pq.Enqueue(distance[start], start);

        while (!pq.IsEmpty())
        {
            int current = pq.Dequeue();
            if (visited[current])
                continue;
            visited[current] = true;

            foreach (var item in adjencyList[current])
            {
                int cost = item.cost;
                int to = item.to;
                if (distance[to] > cost + distance[current])
                {
                    distance[to] = cost + distance[current];
                    pq.Enqueue(distance[to], to);
                }
                    
            }
        }            

    }
    

}
