class Progarm
{
    static void Main(string[] args)
    {
        int[] arr = new int[]{6,4,9,1,5,3,8,2,7};
        InsertionSort(arr, arr.Length);
        foreach (var i in arr)
            Console.WriteLine(i);
    }

    static void InsertionSort(int[]arr,int n)
    {
        for(int i =0; i < n ; i++)
        {
            int key =arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j]>key )
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }
}