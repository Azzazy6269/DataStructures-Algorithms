using System.Diagnostics;
using System.Runtime.CompilerServices;

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
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        graph.DFS(3);
        stopwatch.Stop();
        Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

    }
}

class Graph
{
    List<int> [] adjencyList;
    int size;

    public Graph(int size)
    {
        if (size < 1)
            throw new Exception("Can't create the graph");
        this.size = size;
        adjencyList = new List<int>[size];
        for (int i = 0; i < size; i++)
        {
            adjencyList[i] = new List<int>();
            AddEdge(i, i);
        }

    }

    public void AddEdge(int from,int to)
    {
        adjencyList[from].Add(to);  
    }

    public void DFS(int start)
    {
        bool[] IsExplored =new bool[size]; ;
        int count = 0;
        Traverse(start);

        void Traverse(int start)
        {
            IsExplored[start] = true;
            Console.WriteLine(start);
            count++;
            int i = 1;
            while ( i < adjencyList[start].Count&&count<adjencyList.Length)
            {
                 if (!IsExplored[adjencyList[start][i]])
                     Traverse(adjencyList[start][i]);
                i++;
            }
        }
            
    }
    
}