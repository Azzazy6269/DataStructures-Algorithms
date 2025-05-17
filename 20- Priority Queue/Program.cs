class Progarm
{
    static void Main(string[] args)
    {
        try
        {
            var q = new priorityQueue<int>();
            q.list = [(1, 3), (1, 4), (2, 9), (2, 8), (3, 5), (3, 6)];
            q.BuildHeap();
            foreach (var item in q.list)
            {
                Console.WriteLine(item.value);
            }

            Console.WriteLine(q.Peek());
            q.Enqueue(2, 11);
            q.Dequeue();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
class priorityQueue<T>
{
    public List<(int priority, T value)> list = new List<(int, T)>();

     void HeapfiyAt(int i)
    {
        int right = 2 * i + 2;
        int left = 2 * i + 1;
        int min = i;
        if (left < list.Count && list[left].priority < list[min].priority)
            min = left;
        if (right < list.Count && list[right].priority < list[min].priority)
            min = right;
        if (min != i)
        {
            var temp = list[i];
            list[i] = list[min];
            list[min] = temp;
            
            HeapfiyAt(min);
        }
    }
    public void BuildHeap()
    {
        int parent = ((list.Count / 2) - 1);
        for (int i = parent; i >= 0; i--)
        {
            HeapfiyAt(i);
        }
    }
    public T Peek()
    {
        if (IsEmpty())
            throw new Exception("Queue is empty");
        return list[0].value;
    }
    public void Enqueue(int priority,T value)
    {
        list.Add((priority, value));
        int i = list.Count - 1;
        
        while (i>0)
        {
            int parent = (i - 1) / 2;

            if (list[i].priority < list[parent].priority)
            {
                var temp = list[i]; 
                list[i] = list[parent];
                list[parent] = temp;
                i = parent;
            }
            else { break; }
        }
    }
    public T Dequeue()
    {
        if (IsEmpty())
            throw new Exception("Queue is empty");
        var _return = list[0];
        int i = 0;
        list[0] = list[list.Count-1];
        list.RemoveAt(list.Count-1);
        HeapfiyAt(0);
        return _return.value;
    }
    public bool IsEmpty() => (list.Count == 0);

}
    