
var s = new Stack("a", "b", "c");

// size = 3, Top = 'c'
Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
var deleted = s.Pop();
// Извлек верхний элемент 'c' Size = 2
Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
s.Add("d");
// size = 3, Top = 'd'
Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
s.Pop();
s.Pop();
s.Pop();
// size = 0, Top = null
Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
try
{
    s.Pop();
}
catch (Exception e)
{
    Console.WriteLine($"Got an Exception popping nothing (just as planned): {e.Message}");
}

var s2 = new Stack("a", "b", "c");
s2.Merge(new Stack("1", "2", "3"));
Console.WriteLine($"size = {s2.Size}, Top = '{s2.Top}'");

var s3 = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
// в стеке s теперь элементы - "c", "b", "a" "3", "2", "1", "В", "Б", "А" <- верхний
Console.WriteLine($"size = {s3.Size}, Top = '{s3.Top}'");

public static class StackExtension
{
    public static void Merge (this Stack stack, Stack mergingStack)
    {
        while (mergingStack.Size > 0)
        {
            stack.Add(mergingStack.Pop()); 
        }
    }
}

public class Stack
{
    private List<string> _stack = new List<string>();

    public Stack(params string[] values)
    {
        _stack.AddRange(values);
    }

    public void Add(string value)
    {
        _stack.Add(value);
    }

    public string Pop()
    {
        if (_stack.Count == 0)
            throw new Exception("Empty stack");
        var removed = _stack.Last();
        _stack.RemoveAt(_stack.Count - 1);
        return removed;
    }

    public static Stack Concat(params Stack[] stacks)
    {
        Stack resultStack = new Stack();
        foreach (var stack in stacks)
            resultStack.Merge(stack);
        return resultStack;
    }
    public int Size => _stack.Count;

    public string Top
    {
        get
        {
            if (_stack.Count == 0)
                return null;
            return _stack.Last();
        }
    }
}
