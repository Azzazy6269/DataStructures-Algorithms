class Program
{
    static void Main(string[] args)
    {
        LinkedStack<int> a = new LinkedStack<int>();
        a.push(15);
        a.push(25);
        a.push(35);
        int x=0;
        a.Pop(ref x);
        try {
            a.Print();
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}

 class LinkedStack<T>
{
    class Node // class in c# is a reference type so you don't have to use pointers as each node created in (Node next) would be like a pointer 
    {
        public T item;
        public Node next;
    }
    Node Top;
    public LinkedStack()
    {
        Top = null;
    }

    public void push(T element)
    {
        Node newNode = new Node();
        newNode.item = element;
        newNode.next = Top;
        Top = newNode;
    }
    public void Pop()
    {
        if (IsEmpty())
        {
            throw new Exception("LinkedStack is empty");
        }
        Top = Top.next; // GC will delete the Poped node as there's no reference to it
    }
    public void Pop(ref T variable)
    {
        if (IsEmpty())
        {
            throw new Exception("LinkedStack is empty");
        }
        variable = Top.item;
        Top = Top.next;
    }
    public T GetTop()
    {
        return Top.item;
    }
    public void Print()
    {
        if (IsEmpty())
        {
            throw new Exception("LinkedStack is empty");
        }
        Node temp = Top;
        while (temp is not null)
        {
            Console.WriteLine(temp.item);
            temp = temp.next;
        }
    }
    public bool IsEmpty()
    {
        if (Top is null) 
        {
            throw new Exception("LinkedStack is empty");
        }
        return (Top is null);
    }

}