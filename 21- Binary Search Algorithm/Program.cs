class Program
{
    static void Main(string[] args)
    {
        int[] arr = [23, 55, 11, 62, 18, 93, 42, 16, 24, 31, 21, 88, 51, 15, 64, 79 ];
        int[] arr2 = [10,20,30,40,50];
        Array.Sort(arr); // usually quick sort
        try
        {
            Console.WriteLine(BinarySearch(arr, 24));
            Console.WriteLine(BinarySearch(arr2, 60));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
    static int BinarySearch(int[] arr, int element)
    {
        int l = 0;
        int h = arr.Length - 1;
        int m;

        while (true)
        {
            m = (l + h) / 2;
            if (arr[m] == element) return m;
            if (h == l) throw new Exception("element isn't exist");
            if (arr[m] > element) h = m - 1 ;
            else l = m + 1;
        }
    }
}
