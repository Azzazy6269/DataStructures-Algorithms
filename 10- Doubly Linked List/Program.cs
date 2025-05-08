class Progarm
{
    static void Main(string[] args)
    {
        try
        {
            var list = new LinkedList<int>();
            list.InsertAtFirst(1);
            list.InsertAtLast(2);
            list.InsertAtLast(3);
            list.InsertAtLast(5);
            list.InsertAtIndex(6, 4);
            list.InsertAtIndex(0, 0);
            list.InsertAtIndex(4, 4);
            list.Print();
            Console.WriteLine("---------------");
            Console.WriteLine(list.Get(5)+"\n---------------");
            list.DeleteAtFirst();
            list.DeleteAtLast();
            list.DeleteAtIndex(0);
            list.DeleteAtIndex(3);
            list.DeleteAtIndex(1);
            
            list.Print();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

class LinkedList<T>
{
    Node head;
    Node tail;
    int length;
    class Node
    {
        public T item;
        public Node next;
        public Node previous;
    }
    public void InsertAtFirst(T element)
    {
        Node newNode = new Node();
        newNode.item = element;
        if (IsEmpty())
        {
            head = tail = newNode;
        }
        else
        {
            Node temp = head;
            head.previous = newNode;
            head = newNode;
            head.next = temp;
            head.previous = null;
        }
        length++;
    }
    public void InsertAtLast(T element)
    {
        Node newNode = new Node();
        newNode.item = element;
        if (IsEmpty())
        {
            head = tail = newNode;
        }
        else
        {
            Node temp = tail;
            tail.next = newNode;
            tail = newNode;
            tail.previous = temp;
            tail.next = null;
        }
        length++;
    }
    public void InsertAtIndex(T element,uint index)
    {
        if (index > length)
            throw new Exception("Index is out of range");
        if (index == length) { InsertAtLast(element); }
        else if (index == 0) { InsertAtFirst(element); }
        else
        {
            Node newNode = new Node();
            newNode.item = element;
            Node temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
            Node previous = temp.previous;
            previous.next = newNode;
            newNode.previous = previous;
            newNode.next = temp;
            temp.previous = newNode;
            length++;
        }
           
    }
    public void DeleteAtFirst()
    {
        if (IsEmpty())
            throw new Exception("Linked list is empty");
        if (length == 1)
        {
            head = tail = null;
        }
        else
        {
            head = head.next;
            head.previous = null;
        }
        length--;
    }
    public void DeleteAtLast()
    {
        if (IsEmpty())
            throw new Exception("Linked list is empty");
        if (length == 1)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.previous;
            tail.next = null;
        }
        length--;
    }
    public void DeleteAtIndex(uint index)
    {
        if (IsEmpty())
                throw new Exception("Linked list is empty");
        if(index == 0) { DeleteAtFirst(); }
        else if (index == length-1) { DeleteAtLast(); }
        else
        {
            Node temp = head;
            for(int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
            temp.previous.next = temp.next;
            temp.next.previous = temp.previous;
            length--;
        }
    }
    public T Get(uint index)
    {
        if (IsEmpty())
            throw new Exception("Linked list is empty");
        if (index == 0) { return head.item; }
        else if (index == length - 1) { return tail.item; }
        else 
        {
            Node temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
            return temp.item;
        }
           
    }
    public void Print()
    {
        if (IsEmpty())
            throw new Exception("Linked list is empty");
        Node temp = head;
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(temp.item);
            temp = temp.next;
        }
    }
    public bool IsEmpty() => length == 0;
}