class Program
{
    static void Main(string[] args)
    {
        int[] x = new int[] { 100, 20, 50, 60, 30, 90 ,40,10,70,80};
        BubbleSort(x, x.Length);
        foreach (var i in x)
            Console.WriteLine(i);
    }
    static void BubbleSort(int[]arr,int n)
    {
        
        for(int i = 0; i < n - 1; i++) 
        {
            for(int j = 0; j < n-i-1; j++)
            {
                if (arr[j] > arr[j+1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j+1];
                    arr[j+1] = temp;
                    
                }
                    
            }
        }
    }

}