using System;
using System.Collections;
using System.Collections.Generic;

namespace NSA.DataStructures
{
    public sealed class LinkedList<T> : IEnumerable<LinkedList<T>.ListNode<T>>
    {
        private ListNode<T> _head;

        private ListNode<T> _tail;

        private int _count;
        
        private readonly IComparer<T> _comparer;

        public int Count => _count;

        public LinkedList(IComparer<T> comparer = null)
        {
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public LinkedList(ListNode<T> head, IComparer<T> comparer = null) : this(comparer)
        {
            _head = head ?? throw new ArgumentNullException(nameof(head));
            _tail = head;
            _count = 1;
        }

        public void AddLast(ListNode<T> node)
        {
            if (_count == 0)
                AddIfEmpty(node);
            else
            {
                _tail.Next = node;
                _tail = node;
            }

            _count++;
        }

        public void AddFirst(ListNode<T> node)
        {
            if (Count == 0)
                AddIfEmpty(node);
            else
            {
                node.Next = _head;
                _head = node;
            }

            _count++;
        }

        public int PositionOf(T item)
        {
            var position = 1;
            foreach (var node in this)
            {
                if (_comparer.Compare(node.Value, item) == 0)
                    return position;
                
                position++;
            }

            return -1;
        }
        
        public ListNode<T> GetAt(int position)
        {
            if (position == 1)
                return _head;

            if (position == _count)
                return _tail;

            var currentPosition = 0;
            using var enumerator = GetEnumerator();
            while (currentPosition++ != position)
                enumerator.MoveNext();

            return enumerator.Current;
        }

        public void RemoveAt(int position)
        {
            if (position < 1 || position > _count)
                throw new IndexOutOfRangeException(
                    $"Position should be greater than 0 and less than '{nameof(Count)} + 1'.");

            var previous = GetAt(position - 1);
            var removing = previous.Next;
            previous.Next = previous.Next.Next;
            removing.Next = null;
            _count--;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void Reverse()
        {
            var head = _head;
            _head = ReverseInternal(_head);
            _tail = head;
        }

        private ListNode<T> ReverseInternal(ListNode<T> head)
        {
            if (head == null || head.Next == null)
                return head;

            var current = ReverseInternal(head.Next);

            head.Next.Next = head;
            head.Next = null;

            return current;
        }

        private void AddIfEmpty(ListNode<T> node)
        {
            _head = node;
            _tail = node;
        }

        public IEnumerator<ListNode<T>> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public sealed class ListNode<TValue>
        {
            public ListNode<TValue> Next { get; set; }

            public T Value { get; set; }
        }
    }
}