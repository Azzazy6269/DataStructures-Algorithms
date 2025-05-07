using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        var q = new LinkedQueue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);
        q.Enqueue(5);
        q.Dequeue();
        q.print();
    }
}

class LinkedQueue<T>
{
    Node rear;
    Node front;
    class Node
    {
       public T item;
       public Node next;
    }
    public LinkedQueue()
    {
        rear = new Node();
    }

    public void Enqueue(T element)
    {
        Node newNode = new Node();
        newNode.item = element;
        if (IsEmpty())
        {
            rear= newNode;
            front = rear;
        }
        else 
        {
            rear.next = newNode;
            rear = newNode;
        }
            
        
    }
    public T Dequeue()
    {
        if (IsEmpty())
            throw new Exception("Queue is empty");
        T temp = front.item;
        front = front.next;
        if (front is null)
            rear = null;
        return temp;
    }
    public T GetFront()
    {
        if (IsEmpty())
            throw new Exception("Queue is empty");
        T temp = front.item;
        return temp;
    }
    public void print()
    {
        if (IsEmpty())
            throw new Exception("Queue is empty");
        var temp = front;
        while (temp is not null)
        {
            Console.WriteLine(temp.item);
            temp = temp.next;
        }
    }

    public bool IsEmpty() => front == null;
}