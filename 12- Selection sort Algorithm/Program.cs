class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[] { 2, 8, 7, 1, 5, 3, 4, 6 };
        SelectionSort_Asc(arr, 8);
        foreach (var i in arr)
        {
            Console.WriteLine(i);
        }

    }
    static void SelectionSort_Asc(int[] arr,int n)
    {
        int minIndex;
        for(int i = 0; i < n - 1; i++)
        {
            minIndex = i;
            for (int j = i+1; j < n; j++)
            {
                if (arr[minIndex] > arr[j])
                {
                    minIndex = j;
                }
                   
            }
            int temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }
        
    }
    static void SelectionSort_Desc(int[] arr, int n)
    {
        int minIndex;
        for (int i = 0; i < n - 1; i++)
        {
            minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[minIndex] > arr[j])
                {
                    minIndex = j;
                }

            }
            int temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }

    }
}