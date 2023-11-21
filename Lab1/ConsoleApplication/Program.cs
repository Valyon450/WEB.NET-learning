using MyCollectionLibrary;

var stack = new MyStack<int>();

stack.OnItemAdded += (sender, item) => Console.WriteLine($"Item added: {item}");
stack.OnItemRemoved += (sender, item) => Console.WriteLine($"Item removed: {item}");
stack.OnClear += (sender, item) => Console.WriteLine($"Stack cleared");

stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Peek());

Console.WriteLine("Stack contents:");
foreach (var item in stack)
{
    Console.WriteLine(item);
}
