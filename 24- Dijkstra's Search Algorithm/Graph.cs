class Graph
{
    List<(int cost,int to)>[] adjencyList;
    int start;
    int size;
    bool[] Visited;
    public int[] Distance;
    public int[] Parent;
    priorityQueue<int> pq = new priorityQueue<int>();
    public Graph(int size)
    {
        if (size < 1)
            throw new Exception("Can't create the graph");
        this.size = size;
        Visited = new bool[size];
        Parent = new int[size];
        Distance = new int[size];
        adjencyList = new List<(int cost, int to)>[size];
        for (int i = 0; i < size; i++)
        {
            adjencyList[i] = new List<(int cost, int to)>();
        }
        
    }

    public void AddEdge(int from, int to,int cost)
    {
        adjencyList[from].Add((cost,to));
    }

    public void Dijkstra(int start)
    {
        this.start = start;
        if (start >= size)
            throw new Exception("this node ism't in the graph");
        for (int i = 0; i < Visited.Length; i++)
        {
            Visited[i] = false;
        }
        for (int i = 0; i < Distance.Length; i++)
        {
            Distance[i] = int.MaxValue;
        }
        for (int i = 0; i < Parent.Length; i++)
        {
            Parent[i] = -1;
        }
        Distance[start] = 0;
        pq.Enqueue(Distance[start], start);

        while (!pq.IsEmpty())
        {
            int current = pq.Dequeue();
            if (Visited[current])
                continue;
            Visited[current] = true;

            foreach (var item in adjencyList[current])
            {
                int cost = item.cost;
                int to = item.to;
                if (Distance[to] > cost + Distance[current])
                {
                    Distance[to] = cost + Distance[current];
                    Parent[to] = current;
                    pq.Enqueue(Distance[to], to);
                }
                    
            }
        }            

    }
    public void FindPath(int destination)
    {
        if (destination >= size)
            throw new Exception("this node isn't in the graph");
        if (destination == start)
            throw new Exception("start node is the destination node");
        if (Distance[destination] == int.MaxValue)
            throw new Exception("there's no path from start node to destination node");
        var stack = new Stack<int>();
        int current = destination;
        int parent;
        stack.Push(current);
        while (current!=start)
        {
            current = Parent[current];
            stack.Push(current);
        }
        foreach (var item in stack)
        {
            if(item != destination)
            {
                Console.Write(item + " -> ");
            }
            else
            {
                Console.Write(item);
            }
            
        }
    }
    

}
