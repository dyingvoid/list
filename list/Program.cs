namespace list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackVisualisation stackVisualisation = new();
            Console.WriteLine();
            QueueVisualisation queueVisualisation = new();
            Console.WriteLine();
            //Tests tests = new();

            //LinkedListDemonstartion();
        }

        static void LinkedListDemonstartion()
        {
            var list = new LinkedList<int>();

            for(int i = 0; i < 20; i++)
            {
                list.Insert(i / 2);
            }
            list.Print();
            Console.WriteLine();

            Console.WriteLine("1) Reverse");
            list.Reverse();
            list.Print();
            Console.WriteLine();

            Console.WriteLine("2) Place head to tail, then tail to head");
            list.HeadToTail();
            list.Print();
            list.TailToHead();
            list.Print();
            Console.WriteLine();

            Console.WriteLine("3) Number of unique items");
            Console.WriteLine(list.UniqueNumber() + "\n");

            Console.WriteLine("4) Deleting duplicates");
            list.DeleteDuplicates();
            list.Print();
            Console.WriteLine();

            Console.WriteLine("5) Insert self after first x(5)");
            list.InsertSelf(5);
            list.Print();
            Console.WriteLine();

            Console.WriteLine("6) Insert in order.");
            list.InsertOrder(7);
            list.Print();
            Console.WriteLine();

            Console.WriteLine("7) Delete all nodes with data E(7)");
            list.DeleteNodes(7);
            list.Print();
            Console.WriteLine();

            Console.WriteLine("8) Insert F(7)(6) before E(8)(20)");
            list.TryInsertBefore(7, 8);
            list.TryInsertBefore(6, 20);
            list.Print();

            Console.WriteLine("9) Add list E to list L");
            var list2 = list.CreateCopy();
            list2.Reverse();
            list.Insert(list2);
            list.Print();
            Console.WriteLine();

            Console.WriteLine("10) Split list by value");
            var split = list.Split(1);
            Console.WriteLine("First list:");
            list.Print();
            Console.WriteLine("Second list:");
            split.Print();
            Console.WriteLine();

            Console.WriteLine("11) Multiply list by two");
            list.InsertSelfEnd();
            list.Print();
            Console.WriteLine();

            Console.WriteLine("12) Swap 5 and 9");
            list.Swap(list.Find(5), list.Find(9));
            list.Print();
        }
    }
}