using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    public class Queue<T> where T : notnull, IComparable<T>
    {
        public LinkedList<T> List { get; }

        public Queue()
        {
            List = new();
        }

        // Вставляем элемент
        public void EnQueue(T element)
        {
            List.Insert(element);
            List.HeadToTail();
        }
        
        // Проверяем на пустоту
        public bool IsEmpty()
        {
            if (List.Head != null)
                return false;
            return true;
        }
        
        // Первый элемент
        public Node<T>? First()
        {
            return List.Head;
        }

        // Вытягиваем элемент
        public T DeQueue()
        {
            if (IsEmpty())
                return (T)Convert.ChangeType("error: Невозможно взять элемент, так как очередь пустая", typeof(T));
            var element = List.Head;
            List.DeleteNode(element);
            return element.Data;
        }
    }
}