using MyCollectionLibrary;

var stack = new MyStack<int>();

stack.OnItemAdded += (sender, item) => Console.WriteLine($"Item added: {item}");
stack.OnItemRemoved += (sender, item) => Console.WriteLine($"Item removed: {item}");
stack.OnClear += (sender, item) => Console.WriteLine($"Stack cleared");

stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine($"Pop: {stack.Pop()}");
Console.WriteLine($"Peek: {stack.Peek()}");

bool isContains = stack.Contains(2);
if (isContains)
    Console.WriteLine("Stack contains 2");
else
    Console.WriteLine("Item 2 is not in the collection");

isContains = stack.Contains(3);
if (isContains)
    Console.WriteLine("Stack contains 3");
else
    Console.WriteLine("Item 3 is not in the collection");

Console.WriteLine("Stack contents:");
foreach (var item in stack)
{
    Console.WriteLine($"Item: {item}");
}

stack.Clear();

Console.WriteLine("Stack contents:");
foreach (var item in stack)
{
    Console.WriteLine(item);
}

