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

class MaxHeap
{
    int[] arr;
    public MaxHeap(int[]arr)
    {
        this.arr = arr;
        BuildHeap(arr);
    }

    public void HeapfiyAt(int[] arr,int i )
    {
        int right = 2 * i + 2;
        int left = 2 * i + 1;
        int max = i;
        if (left < arr.Length && arr[left] > arr[max] )
           max = left;
        if (right < arr.Length && arr[right] > arr[max] )
           max = right;
        if (max != i)
        {
            int temp = arr[i];
            arr[i] = arr[max];
            arr[max] = temp;
            HeapfiyAt(arr,max);
        }
    }
    public void BuildHeap(int[] arr)
    {
        int parent = ((arr.Length/2)-1);
        for (int i = parent ; i>=0; i--)
        {
             HeapfiyAt(arr,i);
        }
    }
}