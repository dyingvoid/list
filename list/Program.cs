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
            list.Reverse();
            list.Print();
        }
    }

    public class Node<T>
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

    public class LinkedList<T>
    {
        public Node<T> Head { get; set; }

        public void Insert(T data)
        {
            var node = new Node<T>(data);
            node.Next = Head;
            
            if(Head != null)
                Head.Prev = node;

            Head = node;
        }

        public Node<T> Last()
        {
            var temp = Head;

            while(temp.Next != null)
                temp = temp.Next;

            return temp;
        }

        public void Reverse()
        {
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