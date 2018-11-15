using System;
using System.Collections.Generic;

namespace QueueWithMax
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example for work of queue
            // Moving max implementation for queue length 2
            var movMaxList = new[] { 1, 2, 5, 1, 0, 6 }.MovingMax(2);
            foreach (var num in movMaxList)
                Console.WriteLine(num);           
        }       
    }

    public static class IEnumerableExtensions
    {        
        public static IEnumerable<int> MovingMax(this IEnumerable<int> data, int windowWidth)
        {           
            var queue = new MyQueue<int>();
            foreach (var value in data)
            {
                queue.Enqueue(value);
                if (queue.Count > windowWidth)
                {
                    queue.Dequeue();
                    yield return queue.Max;
                }
                else
                    yield return queue.Max;
            }            
        }
    }
}
