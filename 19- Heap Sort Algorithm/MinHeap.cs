class MinHeap
{
    int[] arr;
    public MinHeap(int[] arr)
    {
        this.arr = arr;
        BuildHeap(arr);
    }

    public void HeapfiyAt(int[] arr, int i)
    {
        int right = 2 * i + 2;
        int left = 2 * i + 1;
        int min = i;
        if (left < arr.Length && arr[left] < arr[min])
            min = left;
        if (right < arr.Length && arr[right]< arr[min])
            min = right;
        if (min != i)
        {
            int temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
            HeapfiyAt(arr, min);
        }
    }
    public void BuildHeap(int[] arr)
    {
        int parent = ((arr.Length / 2) - 1);
        for (int i = parent; i >= 0; i--)
        {
            HeapfiyAt(arr, i);
        }
    }
}