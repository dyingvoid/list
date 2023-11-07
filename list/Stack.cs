using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    public class Stack<T> where T : notnull, IComparable<T>
    {
        public LinkedList<T> List { get; }

        public Stack()
        {
            List = new();
        }

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
        }

        // Вытягиваем элемент (сделать защиту от падения)
        public T Pop()
        {
            if (IsEmpty())
                return (T)Convert.ChangeType("error: Невозможно взять элемент, так как очередь пустая", typeof(T));
            var element = List.Head;
            List.DeleteNode(element!);
            return element.Data;
        }

        // Вершина
        public Node<T>? Top()
        {
            return List.Head;
        }
    }
}
