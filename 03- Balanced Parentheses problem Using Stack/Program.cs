
class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine(IsBalanced("{}{l}"));
        Console.WriteLine(IsBalanced("{Ahmed(16)}"));
        Console.WriteLine(IsBalanced("(osama)elsayed"));
        Console.WriteLine(IsBalanced("{([])}"));
        Console.WriteLine(IsBalanced("{(])}"));
    }

    static bool IsBalanced(string context)
    {
        Stack<char> s = new Stack<char>();
        foreach (var i in context)
        {
            if (i == '(' || i == '{' || i == '[')
            {
                s.Push(i);
            }else if(i == ')' || i == '}' || i == ']')
            {
                if (s.Count==0 || !IsPair(s.Peek() , i))
                {
                    return false;
                }
                s.Pop();
            }
            
        }
        return true;
    }
    static bool IsPair(char open ,char close)
    {
        if (open == '{' && close == '}')
            return true;
        if (open == '[' && close == ']')
            return true;
        if (open == '(' && close == ')')
            return true;
        return false;
    }
}