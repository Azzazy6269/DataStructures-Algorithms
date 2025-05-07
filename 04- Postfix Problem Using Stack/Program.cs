class Program
{
    static void Main()
    {
      Console.WriteLine(  postfix("55/2+19*-"));// = -6

    }

    static int postfix(string Equation)
    {
        int x, y, z = 0;
        var s = new Stack<int>();
        foreach (var i in Equation)
        {
            if (i == '+' || i == '-' || i == '*' || i == '/')
            {
                x = Convert.ToInt32(s.Pop());
                y = Convert.ToInt32(s.Pop());
                z = 0;
                switch (i)
                {
                    case '+': z = y + x; break;
                    case '-': z = y - x; break;
                    case '*': z = y * x; break;
                    case '/': z = y / x; break;
                }
                
                s.Push(z);
            }
            else
            {
                s.Push(Convert.ToInt32(i-'0'));
            }


        }
        return s.Pop();

    }
}