using System;
using System.Collections.Generic;
using UnityEngine;

namespace DataStrucuture
{
    public class Stack<T>
    {
        private Queue<T> mainQueue;
        private Queue<T> subQueue;
        public Stack()
        {
            mainQueue = new Queue<T>();
            subQueue = new Queue<T>();
        }
        public void Push(T data)
        {
            mainQueue.Enqueue(data);
        }
        public T Pop()
        {
            for (int i = mainQueue.Count - 1; i > 0; i--)
            {
                subQueue.Enqueue(mainQueue.Dequeue());
            }
            T result = mainQueue.Dequeue();
            mainQueue = subQueue;
            subQueue = new Queue<T>();
            return result;
        }
    }
}

