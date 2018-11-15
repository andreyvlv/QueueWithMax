using System;
using System.Collections.Generic;

namespace QueueWithMax
{    
    struct QueueItem<T>
    {
        public T item;
        public T max;

        public QueueItem(T item, T max)
        {
            this.item = item;
            this.max = max;
        }
    }

    // This algo is optimized for O(1) max
    class MyQueue<T> where T : IComparable<T>
    {
        Stack<QueueItem<T>> s1 = new Stack<QueueItem<T>>();
        Stack<QueueItem<T>> s2 = new Stack<QueueItem<T>>();

        public int Count { get { return s1.Count + s2.Count; } }
      
        public T Max
        {
            get
            {
                if (s1.Count == 0 || s2.Count == 0)
                    return s1.Count == 0 ?
                        s2.Peek().max :
                        s1.Peek().max;
                else
                    return s1.Peek().max.CompareTo(s2.Peek().max) > 0 ?
                        s1.Peek().max :
                        s2.Peek().max;
            }
        }

        public void Enqueue(T value)
        {
            T max = s1.Count == 0 ?
                value :
                value.CompareTo(s1.Peek().max) > 0 ?
                    value :
                    s1.Peek().max;
            s1.Push(new QueueItem<T>(value, max));
        }

        public T Dequeue()
        {
            if (s2.Count == 0)
                while (!(s1.Count == 0))
                {
                    T element = s1.Peek().item;
                    s1.Pop();
                    T max = s2.Count == 0 ? 
                        element :
                        element.CompareTo(s2.Peek().max) > 0 ?
                            element :
                            s2.Peek().max;
                    s2.Push(new QueueItem<T>(element, max));
                }
            T result = s2.Peek().item;
            s2.Pop();
            return result;
        }
    }
}
