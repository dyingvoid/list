using System.Diagnostics.Metrics;
using System.Net.Http.Headers;

namespace list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackVisualisation stackVisualisation = new();
            QueueVisualisation queueVisualisation = new();

            var list = new LinkedList<int>();
            var list2 = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Insert(i);
            }

            list.Print();
            list.Swap(list.Index(3), list.Index(2));
            list.Print();
        }
    }
}