class Program
{
    static void Main(string[] args)
    {
        Stack<int> c = new Stack<int>();
        c.Push(3);
        c.Push('s'); // int 115
        c.Push(5);
        c.Push(28);
        c.Push(1);
        c.Pop();
        c.Print();
        
    }
}

class Stack<T>
{
    private int Top;
    const int  MaxSize = 100;
    private T[] arr = new T[MaxSize];
    public Stack()
    {
        Top = -1;
    }
    public void Push(T element)
    {
        if(Top >= MaxSize - 1)
        {
            throw new StackOverflowException("Stack is full");
        }
        arr[++Top] = element;
    }
    public void Pop()
    {
        if (IsEmpty())
        {
            throw new Exception("Stack is empty");
        }
        --Top;
    }
    public void Pop(ref T variable)
    {
        if (IsEmpty())
        {
            throw new Exception("Stack is empty");

        }
        variable = arr[Top--];
        
    }
    public T GetTop() 
        {
        if (Top <= -1)
        {
            throw new Exception("Stack is empty");
        }
        return arr[Top];
        
    }
    public void Print()
    {
        for(int i = Top; i> -1; i--)
        {
            Console.WriteLine(arr[i]);
        }
    }
    public void UndoPop() => ++Top;
    public int GetNumOfElements() => Top+1;
    public bool IsEmpty() => Top < 0;

}