class Program
{
    static void Main(string[] args)
    {
        try
        {
            var a = new ArrayList<int>(100);
            a.insertAtEnd(0);
            a.insertAtEnd(1);
            a.insertAtEnd(2);
            a.insertAtEnd(3);
            a.insertAtEnd(4);
            a.insertAtEnd(5);
            a.insertAtEnd(6);
            a.insertAtEnd(7);


            a.RemoveAt(4);
            a.InsertAt(4,4);
            a.Print();
            Console.WriteLine("\n"+a.GetIndex(5));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

class ArrayList<T>
{
    T [] arr;
    int MaxSize;
    int length;
    public int GetSize => MaxSize;
    public int GetUsedSize => length;
    public ArrayList(int size)
    {
        if (size <= 0)
            throw new Exception("Can't create array");
        this.MaxSize = size;
        this.length = 0;
        arr = new T [MaxSize] ; 
    }
    public void InsertAt(T element,uint index)
    {
        if (IsFull())
            throw new Exception("Array is full");
        if (index > length)
            throw new Exception("index is out of range");
        for(int i = length; i > index; i--)
        {
            arr[i] = arr[i - 1];
        }
        arr[index] = element;
        length++;
    }
    public void insertAtEnd(T element)
    {
        if (IsFull())
            throw new Exception("Array is full");
        arr[length++] = element;
    }
    public void RemoveAt(uint index)
    {
        if (index > length)
            throw new Exception("index is out of range");
        for (uint i = index; i < length -1 ; i++)
        {
            arr[i] = arr[i + 1];
        }
        length--;
    }
    public int GetIndex(T element)
    {
        for(int i =0;i< length; i++)
        {
            if (arr[i].Equals(element))
                return i;
        }
        return -1;
    }   
    public void Print()
    {
        if (IsEmpty())
            throw new Exception("Array is Empty");
        for(int i =0; i<length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
    public bool IsEmpty() => length <= 0;
    public bool IsFull() => length == MaxSize;
    
}