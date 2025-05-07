class Progarm
{
    static void Main(string[] args)
    {
        try
        {
            var q = new Queue<char>(5);
            q.Enqueue('a');
            q.Enqueue('b');
            q.Enqueue('c');
            q.Enqueue('d');
            q.Enqueue('e');
            q.Dequeue();
            q.Dequeue();
            q.Enqueue('f');
            q.Enqueue('g');
            q.Print();
            Console.WriteLine("---------");
            Console.WriteLine(q.GetFront());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
class Queue<T>
{
    int Max_Length ;
    int rear; // last , tail , back , end
    int front; // first , begin , head
    int length; // count
    T[] array;

    public Queue(int Size)
    {
        if (Size < 1)
            throw new Exception("Can't create the queue");
        Max_Length = Size;
        array = new T[Max_Length];
        front = 0;
        rear = Max_Length - 1;

    }

    public void Enqueue(T element)
    {
        if (IsFull())
            throw new Exception("Queue is full");
        rear = (++rear) % Max_Length;
        array[rear] = element;
        length++;
    }
    public void Dequeue()
    {
        if (IsEmpty())
            throw new Exception("Queue is empty");
        front = (++front) % Max_Length;
        length--;
    }
    public void Dequeue(ref T variable)
    {
        if (IsEmpty())
            throw new Exception("Queue is empty");
        variable = GetFront();
        front = (++front) % Max_Length;
        length--;
    }
    public void Print()
    {
        if (IsEmpty())
            throw new Exception("Queue is empty");
        int count = length;
        int index = front;
        while(count > 0)
        {
            Console.WriteLine(array[index]);
            count--;
            index = (++index) % Max_Length;
        }
    }
    public T GetFront() => array[front];
    public bool IsEmpty() => length == 0;
    public bool IsFull() => length == Max_Length;
}