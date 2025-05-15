class Progarm
{
    static void Main(string[] args)
    {
        int[] x = [17, 3, 24, 12, 9, 6, 26, 29, 1, 32, 2, 15, 14, 23, 11, 4, 7, 21, 25 ];
        var heap = new MaxHeap(x);

        foreach (var item in x)
        {
            Console.WriteLine(item);
        }
        
    }
    
}
