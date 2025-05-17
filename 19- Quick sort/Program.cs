class Program
{
    static void Main(string[] args)
    {
        int[] array = {10, 17, 7, 11,16, 6, 2, 8, 5};
        var sort = new Quick_Sort(array);
        sort.print();
    }
}

class Quick_Sort
{
    int[] arr;
    uint size;
    public Quick_Sort(int[] array)
    {
        arr = array;
        sort(0, arr.Length - 1);
    }

    public void sort(int from,int to)
    {
        int Pivot = from, To = to;
        int i= from+1;
        while (i <= To) 
        {
            if (arr[i] < arr[Pivot])
            {
                Swap(Pivot, i);
                i++;
            }
            else
            {
                Swap(i, To);
                To--;
            }
        }
        if (from < to)
        {
            sort(Pivot + 1, to);
            sort(from, Pivot - 1);
        }

        //if (to > from)
        //{
        //    sort(from, From - 1);
        //    sort(From + 1, to);
        //}
    }
    private void Swap(int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    public void print()
    {
        foreach (var I in arr)
        {
            Console.WriteLine(I);
        }
    }
}