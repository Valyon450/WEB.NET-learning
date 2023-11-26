using System.Collections;
using System.Security.Cryptography.X509Certificates;
using MyCollectionLibrary;

namespace CollectionTests
{
    public class StackTests
    {
        public class PushTests
        {
            [Fact]
            public void Should_Add_Item_To_The_Top()
            {
                var stack = new MyStack<int>();

                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                Assert.True(stack.Contains(1));
                Assert.True(stack.Contains(2));
                Assert.Equal(3, stack.Peek());
            }

            [Fact]
            public void Should_Invoke_Add_Event()
            {
                var stack = new MyStack<int>();
                int pushedItem = 0;
                stack.OnItemAdded += (sender, item) => pushedItem = item;

                stack.Push(1);

                Assert.Equal(1, pushedItem);
            }
        }

        public class PopTests
        {
            [Fact]
            public void Should_Return_Top_Item_And_Remove_It()
            {
                var stack = new MyStack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                var poppedItem = stack.Pop();

                Assert.Equal(3, poppedItem);
                Assert.False(stack.Contains(3));
            }

            [Fact]
            public void Should_Invoke_Remove_Event()
            {
                var stack = new MyStack<int>();
                int removedItem = 0;
                stack.OnItemRemoved += (sender, item) => removedItem = item;

                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                stack.Pop();

                Assert.Equal(3, removedItem);
            }

            [Fact]
            public void Should_Throw_InvalidOperationException_On_Empty_Stack()
            {
                var stack = new MyStack<int>();

                Assert.Throws<InvalidOperationException>(() => stack.Pop());
            }
        }

        public class PeekTests
        {
            [Fact]
            public void Should_Return_Top_Item_Without_Removing()
            {
                var stack = new MyStack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                var peekedValue = stack.Peek();

                Assert.Equal(3, peekedValue);
                Assert.True(stack.Contains(3));
            }

            [Fact]
            public void Should_Throw_InvalidOperationException_On_Empty_Stack()
            {
                var stack = new MyStack<int>();

                Assert.Throws<InvalidOperationException>(() => stack.Peek());
            }
        }

        public class IsEmptyTests
        {
            [Fact]
            public void Should_Return_True_When_Stack_Empty()
            {
                var stack = new MyStack<int>();                

                Assert.True(stack.IsEmpty());
            }

            [Fact]
            public void Should_Return_False_When_Stack_Not_Empty()
            {
                var stack = new MyStack<int>();

                stack.Push(1);
                stack.Push(2);

                Assert.False(stack.IsEmpty());
            }
        }
 
        public class ClearTests
        {
            [Fact]
            public void Should_Clear_Stack()
            {
                var stack = new MyStack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                stack.Clear();

                Assert.Empty(stack);
            }

            [Fact]
            public void Should_Invoke_Cleared_Event()
            {
                var stack = new MyStack<int>();
                bool clearedEventInvoked = false;
                stack.OnClear += (sender, item) => clearedEventInvoked = true;

                stack.Push(1);
                stack.Push(2);
                stack.Clear();

                Assert.True(clearedEventInvoked);
            }
        }

        public class ContainsTests
        {
            [Fact]
            public void Should_Return_True_When_Item_Exist()
            {
                var stack = new MyStack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                Assert.True(stack.Contains(2));
            }

            [Fact]
            public void Should_Return_False_When_Item_Not_Exist()
            {
                var stack = new MyStack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                Assert.False(stack.Contains(4));
            }

            [Fact]
            public void Should_Return_False_When_Stack_Empty()
            {
                var stack = new MyStack<int>();

                Assert.False(stack.Contains(1));
            }
        }

        public class ToStringTests
        {
            [Fact]
            public void Should_Return_String_Stack_Representation()
            {
                var stack = new MyStack<int>();
                stack.Push(1);
                stack.Push(2);                

                var stackToString = stack.ToString();

                Type result = stackToString.GetType();

                string str = "";
                Type expected = str.GetType();

                Assert.Equal(expected, result);
            }

            [Fact]
            public void Should_Return_Correct_String_Items_Representation()
            {
                var stack = new MyStack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                var stackToString = stack.ToString();
                
                Assert.Equal("3\r\n2\r\n1\r\n", stackToString);                
            }
        }
        
    }
}