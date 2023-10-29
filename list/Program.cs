using System.Diagnostics.Metrics;
using System.Net.Http.Headers;

namespace list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();
            var list2 = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Insert(i);
                list2.Insert(i);
            }

            list.Print();
            list.Insert(list2);
            list.Print();

            Console.WriteLine(list.Count);
        }
    }
}