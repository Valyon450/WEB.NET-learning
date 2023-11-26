using System.Collections;
using System.Text;

namespace MyCollectionLibrary;

public class MyStack<T> : IEnumerable<T>
{
    private class Item
    {
        public T? Data { get; set; }
        public Item? Next { get; set; }
    }

    private Item? _top;

    public event EventHandler<T>? OnItemAdded;
    public event EventHandler<T>? OnItemRemoved;
    public event EventHandler? OnClear;

    public void Push(T item)
    {
        var newItem = new Item { Data = item, Next = _top };
        _top = newItem;
        OnItemAdded?.Invoke(this, item);
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        T data = _top.Data;
        _top = _top.Next;
        OnItemRemoved?.Invoke(this, data);
        return data;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        return _top.Data;
    }

    public bool IsEmpty()
    {
        return _top == null;
    }

    public void Clear()
    {
        _top = null;
        OnClear?.Invoke(this, EventArgs.Empty);
    }

    public bool Contains(T item)
    {
        Item? current = _top;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, item))
                return true;

            current = current.Next;
        }

        return false;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var item in this)
        {
            sb.AppendLine(item?.ToString());
        }
        return sb.ToString();
    }

    // Implementation of the IEnumerable<T> interface
    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Implementation of the own IEnumerator<T> interface
    private class MyEnumerator : IEnumerator<T>
    {
        private Item? _current;
        private readonly MyStack<T> _stack;

        public MyEnumerator(MyStack<T> stack)
        {
            _stack = stack;
            _current = null;
        }

        public bool IsHasNext()
        {
            return _current != null;
        }

        public T Current
        {
            get
            {
                if (!IsHasNext())
                    throw new InvalidOperationException("Enumerator is not started.");

                return _current.Data;
            }
        }

        object IEnumerator.Current => _current.Data;

        public void Dispose()
        {
            // Don't need to perform additional actions when freeing resources.
        }

        public bool MoveNext()
        {
            if (!IsHasNext())
                _current = _stack._top;
            else
                _current = _current.Next;

            return IsHasNext();
        }

        public void Reset()
        {
            _current = null;
        }
    }
}