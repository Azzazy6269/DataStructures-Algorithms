class Program
{
    static void Main(string[] args)
    {
        var q1 = new Queue<int>();

        push(ref q1, 1);
        push(ref q1, 2);
        push(ref q1, 3);
        push(ref q1, 4);
        push(ref q1, 5);
        
        Console.WriteLine(pop(ref q1));
        Console.WriteLine(pop(ref q1));
        Console.WriteLine(pop(ref q1));
        Console.WriteLine(pop(ref q1));

        Console.WriteLine(Peek(ref q1));
        Console.WriteLine(IsEmpty(q1));



    }

    static T pop<T>(ref Queue<T> q)
    {
        var q2 = new Queue<T>();
        int count = q.Count;
        for(int i =0;i< count-1; i++)
        {
            
            q2.Enqueue(q.Dequeue());
        }
        T temp = q.Dequeue();
        q = q2;
        return temp;
    }

    static void push<T>(ref Queue<T> q, T element)
    {
        q.Enqueue(element);
    }

    static T Peek<T>(ref Queue<T> q)
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

    static bool IsEmpty<T>(Queue<T> q) => q.Count == 0;
    
}