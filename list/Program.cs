using System.Diagnostics.Metrics;

namespace list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();
            for(int i = 0; i < 10; i++)
            {
                list.Insert(i);
            }

            list.Print();
            list.InsertSelf(4);
            list.Print();

            Console.WriteLine(list.Count);
        }
    }

    public class Node<T> where T : notnull
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Prev { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    //4.3? Если список<int> то count, если не int, то 0
    public class LinkedList<T> where T : notnull
    {
        public Node<T>? Head { get; set; }
        public int Count { get; private set; }

        public void Insert(T data)
        {
            var node = new Node<T>(data);
            node.Next = Head;
            
            if(Head != null)
                Head.Prev = node;

            Head = node;

            Count++;
        }

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

        public Node<T>? Find(T value)
        {
            var temp = Head;

            while(temp != null)
            {
                if (temp.Data.Equals(value))
                    return temp;
                temp = temp.Next;
            }

            return null;
        }

        public Node<T>? Last()
        {
            if (Count == 0 || Count == 1)
                return Head;

            var temp = Head;
            while(temp.Next != null)
                temp = temp.Next;

            return temp;
        }

        public void Reverse()
        {
            if (Count <= 1)
                return;

            Node<T> next = null;
            Node<T> prev = null;
            Node<T> current = Head;

            while(current != null)
            {
                next = current.Next;
                current.Next = current.Prev;
                prev = current;
                current = next;
            }

            Head = prev;
        }

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

        public void TailToHead()
        {
            if (Count <= 1)
                return;

            var last = Last();
            var temp = Head;
            
            if(last.Prev != null)
            {
                last.Prev.Next = null;
            }

            temp.Prev = last;
            last.Next = temp;
            last.Prev = null;
            Head = last;
        }

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

            if(node == Head)
            {
                node.Next.Prev = null;
                Head = node.Next;
                return;
            }
            if(node == Last())
            {
                node.Prev.Next = null;
                node.Prev = null;
                return;
            }

            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            node = null;
        }

        public void DeleteNodes(IEnumerable<Node<T>> nodes)
        {
            foreach(var node in nodes)
                DeleteNode(node);
        }

        public void Print()
        {
            var temp = Head;
            Console.Write(temp.Data + " -> ");

            while(temp.Next != null)
            {
                Console.Write(temp.Next.Data + " -> ");
                temp = temp.Next;
            }

            Console.WriteLine("NULL");
        }
    }
}