class Program
{
    static void Main(string[] args)
    {
        try
        {
            var table = new HashTable<int>(10);
            table.Add(3);
            table.Add(8);
            table.Add(13);
            table.Add(23);
            table.Add(10);
            table.Add(33);
            table.Add(43);
            table.Add(53);

            table.Delete(33);
            Console.WriteLine(table.Contains(33));
            Console.WriteLine(table.Contains(10));
            Console.WriteLine(table.Contains(3));
            Console.WriteLine(table.Contains(23));

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}

class HashTable<T>
{
    Node[] arr;
    class Node
    {
        public T item;
        public Node next;
    }
    public HashTable(uint size)
    {
        arr = new Node[size];
    }
    public void Add(T element)
    {
        int index = Math.Abs(element.GetHashCode()) % arr.Length;
        var newNode = new Node();
        newNode.item = element;
        if (arr[index] is null)
        {
            arr[index] = newNode;
        }
        else
        {
            Node temp = arr[index];
            arr[index] = newNode;
            newNode.next = temp;
        }
            
    }
    public void Delete(T element)
    {
        int index = Math.Abs(element.GetHashCode()) % arr.Length;
        if (arr[index]!=null && arr[index].item.Equals(element))
        {
            arr[index] = arr[index].next;
        }
        else
        {
            Node previous = new Node() ;
            Node temp = arr[index];
            while (!temp.item.Equals(element))
            {
                
                previous = temp;
                temp = temp.next;
                if (temp is null)
                    throw new Exception("element isn't exist");
            }
            previous.next = temp.next;

        }
            
    }
    public bool Contains(T element)
    {
        int index = Math.Abs(element.GetHashCode()) % arr.Length;
        if (arr[index] == null)
            return false;
        Node temp = arr[index];
        while (true)
        {
            if (temp.item.Equals(element))
                return true;
            if (temp.next is null)
                return false;
            temp = temp.next;
        }
    }


}