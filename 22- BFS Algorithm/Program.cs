class Program
{
    static void Main(string[] args)
    {

        var graph = new Graph(7);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 3);

        graph.AddEdge(1, 0);
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 4);

        graph.AddEdge(2, 1);
        graph.AddEdge(2, 5);

        graph.AddEdge(3, 0);
        graph.AddEdge(3, 4);

        graph.AddEdge(4, 1);
        graph.AddEdge(4, 3);
        graph.AddEdge(4, 5);

        graph.AddEdge(5, 2);
        graph.AddEdge(5, 4);
        graph.AddEdge(5, 6);

        graph.AddEdge(6, 5);

        /*
         Graph:
         0 - 1 - 2
         |   |   |
         3 - 4   |
             |   | 
             5 - -
             |
             6
         */

        graph.BFS(3);
        
    } 
}
class Graph
{
    private List<int>[] adjacencyList;
    int size;
    public Graph(int size)
    {
        adjacencyList = new List<int>[size];
        for (int i = 0; i < size; i++)
        {
            adjacencyList[i] = new List<int>();
            adjacencyList[i].Add(i);
        }
        this.size = size;
    }

    public void AddEdge(int from, int to)
    {
        adjacencyList[from].Add(to);
    }

    public void BFS(int start)
    {
        var Waiting = new Queue<int>();
        bool[] IsExplored = new bool[size];
        int count = 0;

        Waiting.Enqueue(adjacencyList[start][0]);
        Traverse(Waiting.Peek());

        void Traverse(int start)
        {
            for (int i = 0; i < adjacencyList[start].Count; i++)
            {
                if (!Waiting.Contains(adjacencyList[start][i]) && !IsExplored[adjacencyList[start][i]]) // Check that it isn't in explored list or in waiting list
                   Waiting.Enqueue(adjacencyList[start][i]);
            }

            int explored = Waiting.Dequeue();
            IsExplored[explored] = true;
            Console.WriteLine(explored);

            if (Waiting.Count()>0)
                Traverse(Waiting.Peek());
        }
        

    }
    
}

