class Program
{
    static void Main(string[] args)
    {
        try
        {
            var list = new LinkedList<int>();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);

            list.InsertFirst(-1);
            list.InsertFirst(-2);
            list.InsertFirst(-3);

            list.InsertAtposition(0, 3);

            Console.WriteLine(list.Get(3) + "\n----------");
            //list.DeleteLast();
            //list.DeleteFirst();
            //list.DeleteAtIndex(2);
            //list.DeleteElement(1);

            list.Reverse();
            list.Print();
        }
        catch (Exception ex)
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
    }
    public LinkedList()
    {
        
    }
    public void InsertLast(T element)
    {
        Node newnode = new Node();
        newnode.item = element;
        if (isEmpty())
        {
            head = newnode;
            head.next = null;
            tail = head;
        }
        else
        {
            tail.next = newnode;
            tail = newnode;
        }
        length++;
            

    }
    public void InsertFirst(T element)
    {
        Node newnode = new Node();
        newnode.item = element;
        if (isEmpty())
        {
            head = newnode;
            newnode.next = null;
            tail = head;
        }
        else
        {
            newnode.next = head;
            head = newnode;
        }
        length++;

    }
    public void InsertAtposition(T element , uint index)
    {
        if (index > length)
            throw new Exception("Index is out of range");
        if(index == length) { InsertLast(element); }
        else if(index == 0) { InsertFirst(element); }
        else 
        {
            Node newnode = new Node();
            newnode.item = element;
            Node temp = head;
            for (int i = 0; i < index-1; i++)
            {
                temp = temp.next;
            }
            newnode.next = temp.next;
            temp.next = newnode;
            length++;
        }
            


    }
    public void DeleteLast()
    {
        if (isEmpty())
            throw new Exception("Linked list is empty");
        if(length ==1) { head = tail = null;length--; }
        else 
        {
            Node temp = head;
            for (int i = 0; i < length - 2; i++)
            {
                temp = temp.next;
            }
            temp.next = null;
            tail = temp;
            length--;
        }
            
    }
    public void DeleteFirst()
    {
        if (isEmpty())
            throw new Exception("Linked list is empty");
        if (length == 1) { head = tail = null;  length--; }
        else
        {
            head = head.next;
            length--;
        }
            
    }
    public void DeleteAtIndex(uint index)
    {
        if (index >= length) 
            throw new Exception("index is out of range");
        if (index == 0) { DeleteFirst(); }
        else if (index == length-1) { DeleteLast(); }
        else
        {
            Node temp = head;
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.next;
            }
            Node deletedNode = temp.next;
            temp.next = deletedNode.next;
            length--;

        }
            
    }
    public void DeleteElement(T value)
    {
        if (isEmpty())
            throw new Exception("Linked list is empty");
        Node temp = head;
        Node previousTemp = null;
        for(int i = 0; i < length; i++)
        {
            if (temp.item.Equals(value)) 
            {
                if (temp == head) { DeleteFirst();  }
                else if (temp == tail) { DeleteLast (); }
                else
                {
                    previousTemp.next = temp.next;
                    length--;
                }
                
                return;
            }
            previousTemp = temp;
            temp = temp.next;

        }
        throw new Exception("can't find element");
        
    }
    public T Get(uint index)
    {
        if (isEmpty())
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
    public void Reverse()
    {
        Node previous = null,
             temp = head,
             next;

        for (int i = 0; i < length; i++)
        {
            next = temp.next;
            temp.next = previous;
            previous = temp;
            temp = next;

        }
        head = previous;
        temp = head;
        for (int i = 0; i < length - 1; i++)
        {
            temp = temp.next;
        }
        tail = temp;
    }
    public void Print()
    {
        Node temp = head;
        while(temp != null)
        {
            Console.WriteLine(temp.item);
            temp = temp.next;
        }
    }
    public bool isEmpty() => length == 0;

}