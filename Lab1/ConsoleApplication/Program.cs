using MyCollectionLibrary;

var stack = new MyStack<int>();

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
