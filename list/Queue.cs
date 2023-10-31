using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    public class Queue<T> : LinkedList<T> where T : notnull, IComparable<T>
    {
        public LinkedList<T> List { get; }

        public Queue()
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
        public void EnQueue(T element)
        {
            List.Insert(element);
            List.HeadToTail();
            List.Count++;
        }

        // Вытягиваем элемент
        public T DeQueue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue empty");
            var element = List.Head;
            List.DeleteNode(element!);
            List.Count--;
            return element!.Data;
        }

        // Первый элемент
        public Node<T> First()
        {
            return List.Head!;
        }
    }
}
