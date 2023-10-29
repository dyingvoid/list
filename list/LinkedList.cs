using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    //4.3? Если список<int> то count, если не int, то 0
    public class LinkedList<T> where T : notnull, IComparable<T>
    {
        public Node<T>? Head { get; set; }
        public int Count { get; private set; }

        // Вставить в начало списка
        public void Insert(T data)
        {
            var node = new Node<T>(data);
            node.Next = Head;

            if (Head != null)
                Head.Prev = node;

            Head = node;

            Count++;
        }

        // Вставить список в начало списка
        public void Insert(LinkedList<T> list)
        {
            var node = list.Last();
            while (node is not null)
            {
                node.Next = Head;
                Head = node;
                node = node.Prev;
            }
        }

        //Вставить себя в начало
        public void InsertSelf(T value)
        {
            var foundNode = Find(value);
            var copy = CreateCopy();

            if (foundNode != null)
            {
                var temp = foundNode.Next;
                foundNode.Next = copy.Head;
                copy.Last().Next = temp;
            }
        }

        // Копия себя
        public LinkedList<T> CreateCopy()
        {
            var copy = new LinkedList<T>();

            var temp = Last();
            while (temp != null)
            {
                copy.Insert(temp.Data);
                temp = temp.Prev;
            }

            return copy;
        }

        // Найти первый узел с данными
        public Node<T>? Find(T value)
        {
            var temp = Head;

            while (temp != null)
            {
                if (temp.Data.Equals(value))
                    return temp;
                temp = temp.Next;
            }

            return null;
        }

        //Найти первый узел с данными
        public bool TryFind(T value, out Node<T> node)
        {
            var foundNode = Find(value);
            if (foundNode != null)
            {
                node = foundNode;
                return true;
            }

            node = new Node<T>(default);
            return false;
        }

        // Вставить соблюдая порядок возрастания
        public void InsertOrder(T value)
        {
            var temp = Head;
            while (temp != null)
            {
                if (value.CompareTo(temp.Data) == 1)
                {
                    if (temp.Next == null)
                    {
                        temp.Next = new Node<T>(value);
                        return;
                    }
                    else if (value.CompareTo(temp.Next.Data) == -1 ||
                        value.CompareTo(temp.Next.Data) == 0)
                    {
                        var newNode = new Node<T>(value);

                        newNode.Next = temp.Next;
                        newNode.Prev = temp;
                        temp.Next.Prev = newNode;
                        temp.Next = newNode;
                        return;
                    }
                }

                temp = temp.Next;
            }
        }

        // Вставить перед узлом node
        public bool TryInsertBefore(T value, T node)
        {
            if (!TryFind(node, out var foundNode))
                return false;

            InsertBefore(new Node<T>(value), foundNode);

            return true;
        }

        // Вставить узел nodeInsert перед node
        public void InsertBefore(Node<T> nodeInsert, Node<T> node)
        {
            nodeInsert.Prev = node.Prev;
            nodeInsert.Next = node;

            if (node.Prev != null)
                node.Prev.Next = nodeInsert;

            node.Prev = nodeInsert;

            if (node == Head)
                Head = nodeInsert;
        }

        // Последний элемент
        public Node<T>? Last()
        {
            if (Count == 0 || Count == 1)
                return Head;

            var temp = Head;
            while (temp.Next != null)
                temp = temp.Next;

            return temp;
        }

        // Перевернуть
        public void Reverse()
        {
            if (Count <= 1)
                return;

            Node<T> next = null;
            Node<T> prev = null;
            Node<T> current = Head;

            while (current != null)
            {
                next = current.Next;
                current.Next = current.Prev;
                prev = current;
                current = next;
            }

            Head = prev;
        }

        // Переместить начальный узел в конец
        public void HeadToTail()
        {
            if (Count <= 1)
                return;

            var temp = Head;
            var last = Last();

            last.Next = temp;
            temp.Prev = last;

            if (temp.Next != null)
            {
                temp.Next.Prev = null;
                Head = temp.Next;
                temp.Next = null;
            }
        }

        // Переместить последний узел в начало
        public void TailToHead()
        {
            if (Count <= 1)
                return;

            var last = Last();
            var temp = Head;

            if (last.Prev != null)
            {
                last.Prev.Next = null;
            }

            temp.Prev = last;
            last.Next = temp;
            last.Prev = null;
            Head = last;
        }

        // Найти повторения
        public List<Node<T>> FindDuplicates()
        {
            var dict = new Dictionary<T, int>();
            var duplicates = new List<Node<T>>();
            var temp = Head;

            while (temp != null)
            {
                var result = dict.TryAdd(temp.Data, 1);
                if (!result)
                    duplicates.Add(temp);

                temp = temp.Next;
            }

            return duplicates;
        }

        // удалить первый узел с данными
        public bool DeleteNode(T data)
        {
            var node = Find(data);
            if (node is not null)
            {
                DeleteNode(node);
                return true;
            }

            return false;
        }

        // Удалить узел
        public void DeleteNode(Node<T> node)
        {
            if (Count == 0)
                return;

            Count--;
            if (Count == 1 && node == Head)
            {
                Head = null;
                return;
            }

            if (node == Head)
            {
                node.Next.Prev = null;
                Head = node.Next;
                return;
            }
            if (node == Last())
            {
                node.Prev.Next = null;
                node.Prev = null;
                return;
            }

            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            node = null;
        }

        // Удалить узлы
        public void DeleteNodes(IEnumerable<Node<T>> nodes)
        {
            foreach (var node in nodes)
                DeleteNode(node);
        }

        // Удалить все узлы с data
        public void DeleteNodes(T data)
        {
            while (DeleteNode(data)) ;
        }

        // Вывести в консоль
        public void Print()
        {
            var temp = Head;
            Console.Write(temp.Data + " -> ");

            while (temp.Next != null)
            {
                Console.Write(temp.Next.Data + " -> ");
                temp = temp.Next;
            }

            Console.WriteLine("NULL");
        }
    }
}
