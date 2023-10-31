using System;
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

        public bool IsEmpty()
        {
            if (List.Head != null)
                return false;
            return true;
        }

        public void Push(T element)
        {
            List.Insert(element);
            List.HeadToTail();
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack empty");
            var element = List.Last();
            List.DeleteNode(element!);
            return element!.Data;
        }

        public Node<T> Top()
        {
            return List.Last()!;
        }
    }
}
