class Program
{
    static void Main(string[] args)
    {
        var s = new StackBasedQueue<int>();
        s.push(1);
        s.push(2);
        s.push(3);
        s.push(4);
        s.push(5);
        s.push(6);
        s.push(7);

        s.pop();
        s.pop();

        Console.WriteLine(s.Peek());
        Console.WriteLine(s.IsEmpty());

    }



}

class StackBasedQueue<T>
{
    Queue<T> q;

    public StackBasedQueue()
    {
         q = new Queue<T>();
    }
    public T pop()
    {
        var q2 = new Queue<T>();
        int count = q.Count;
        for (int i = 0; i < count - 1; i++)
        {
            q2.Enqueue(q.Dequeue());
        }
        T temp = q.Dequeue();
        q = q2;
        return temp;
    }
    public void push(T element)
    {
        q.Enqueue(element);
    }

    public T Peek()
    {
        var q2 = new Queue<T>();
        int count = q.Count;
        for (int i = 0; i < count - 1; i++)
        {

            q2.Enqueue(q.Dequeue());
        }
        T temp = q.Dequeue();
        q2.Enqueue(temp);
        q = q2;
        return temp;
    }

    public bool IsEmpty() => q.Count == 0;

}