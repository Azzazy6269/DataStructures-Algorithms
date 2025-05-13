class Program
{
    static void Main(string[] args)
    {
        int[] arr = [2,7,6,4,3,9,1,5,8 ];
        MergeSort(arr);
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }

    }
    static void MergeSort(int[] arr)
    {
        if (arr.Length <= 1)
            return;
        int l = arr.Length;
        int l1 = l / 2;
        int l2 = l - l1;
        int[] left = new int[l1];
        int[] right = new int[l2];
        Array.Copy(arr, left, l1);
        Array.Copy(arr, l1, right, 0, l2);
        MergeSort(left);
        MergeSort(right);

        Merge(arr, left, right);
    }
    static void Merge(int[] arr, int[] left, int[]right) { 
        int i = 0,j=0,k=0;
        while (i<left.Length && j<right.Length)
        {
            if (left[i] < right[j])
            {
                arr[k++] = left[i++];
            }
            else
            {
                arr[k++] = right[j++];
            }
        }
        while (i < left.Length)
        {
            arr[k++] = left[i++];
        }
        while (j < right.Length)
        {
            arr[k++] = right[j++];
        }
    }
}

