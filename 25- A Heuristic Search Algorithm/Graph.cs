using System.Security.Cryptography.X509Certificates;

class Graph
{
    int size;
    int start;
    bool[] Visited;
    int[] Distance;
    int[] Parent;
    List<(int cost, int to, int info)> []adjancyList;
    priorityQueue<int> pq = new priorityQueue<int>();
    public Graph(int size)
    {
        if (size < 1)
            throw new Exception("Can't create the graph");
        this.size = size;
        Visited = new bool[size];
        Distance = new int[size];
        Parent = new int[size];
        adjancyList = new List<(int cost, int to ,int info)>[size];
        for (int i = 0; i < size; i++)
        {
            adjancyList[i] = new List<(int cost, int to, int info)>();
        }
        
    }
    public void AddEdge(int from,int to,int cost, int information)
    {
        adjancyList[from].Add((cost, to,information));
    }

    public void Heustric(int start)
    {
        if (start >= size || start < 0)
            throw new Exception("This Node isn't exist");
        this.start = start;
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
        pq.Enqueue(Distance[start],start);
        while (!pq.IsEmpty())
        {
            int current = pq.Dequeue();
            if (Visited[current])
                continue;

            foreach (var item in adjancyList[current])
            {
                int cost = item.cost;
                int to = item.to;
                int info = item.info;
                if (Distance[to] > (Distance[current] + info+ cost))
                {
                    Distance[to] = Distance[current] + info + cost;
                    Parent[to] = current;
                    pq.Enqueue(Distance[to], to);
                }
            }
            Visited[start] = true;

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
        while (current != start)
        {
            current = Parent[current];
            stack.Push(current);
        }
        foreach (var item in stack)
        {
            if (item != destination)
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