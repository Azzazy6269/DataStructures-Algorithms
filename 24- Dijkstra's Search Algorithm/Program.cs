class Program
{
    static void Main(string[] args)
    {

        var graph = new Graph(7);
        graph.AddEdge(0, 1, 2);
        graph.AddEdge(0, 3, 2);

        graph.AddEdge(1, 0, 2);
        graph.AddEdge(1, 2, 1);
        graph.AddEdge(1, 4, 3);

        graph.AddEdge(2, 1, 1);
        graph.AddEdge(2, 5, 5);

        graph.AddEdge(3, 0, 2);
        graph.AddEdge(3, 4, 1);

        graph.AddEdge(4, 1 ,3);
        graph.AddEdge(4, 3 ,1);
        graph.AddEdge(4, 5 ,2);

        graph.AddEdge(5, 2 ,5);
        graph.AddEdge(5, 4 ,2);
        graph.AddEdge(5, 6 ,1);

        graph.AddEdge(6, 5 ,1);

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
        try
        {
            graph.Dijkstra(3);
            graph.FindPath(2);
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
