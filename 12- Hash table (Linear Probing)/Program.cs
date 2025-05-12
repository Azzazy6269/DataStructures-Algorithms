class Program
{
    static void Main(string[] args)
    {
        try
        {
            var table = new HashTable(10);
                table.Add(3);
                table.Add(8);
                table.Add(13);
                table.Add(23);
                table.Add(10);
                table.Add(33);
                table.Add(43);
                table.Add(53);
                table.Add(5);
                table.Add(3);
                table.Delete(3);

            table.print();
            Console.WriteLine(table.GetIndex(3));

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}

class HashTable
{
    Nullable<int>[] arr;
    readonly int deleted = int.MinValue;
    public HashTable(uint size)
    {
        arr = new Nullable<int>[size];
    }

    public void Add(int num) //Hashing
    {
        int count = 0;
        int index = num % arr.Length;
        while ( arr[index] != null && arr[index] != deleted)
        {
            if (index == arr.Length - 1)
            {
                index = 0;
                count++;
            }
            else
            {
                index++;
                count++;
                if (count >= arr.Length)
                    throw new Exception("Full table!!");
            }
                
        }
        arr[index] = num;
    }
    public void Delete(int num)
    {
        int index= GetIndex(num);
        if (index == -1)
            return;
        arr[index] = deleted;
    }
    public int GetIndex(int num)
    {
        int count = 0;
        int index = num % arr.Length;
        while(count< arr.Length)
        {
            if (arr[index] == num)
                return index;
            else if(index == arr.Length - 1) 
            { 
                index = 0;
                count++;
            }
            else
            {
                index++;
                count++;
            }
                
        }
        return -1;
        
    }
    public void print()
    {
        Console.WriteLine("--------");
        foreach (var item in arr)
        {
            if (item == int.MinValue)
                Console.WriteLine("");
            else
                Console.WriteLine(item);
        }
        Console.WriteLine("--------");

    }
}