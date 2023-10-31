﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    public class Stack<T> : LinkedList<T> where T : notnull, IComparable<T>
    {
        public LinkedList<T> List { get; }

        public Stack()
        {
            List = new();
        }

        public int Count() => this.List.Count;

        // Проверяем на пустоту
        public bool IsEmpty()
        {
            if (List.Head != null)
                return false;
            return true;
        }

        // Вставляем элемент
        public void Push(T element)
        {
            List.Insert(element);
            List.Count++;
        }

        // Вытягиваем элемент
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack empty");
            var element = List.Head;
            List.DeleteNode(element!);
            List.Count--;
            return element!.Data;
        }

        // Вершина
        public Node<T> Top()
        {
            return List.Head!;
        }
    }
}
