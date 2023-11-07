using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    public class QueueVisualisation
    {
        public QueueVisualisation()
        {
            Console.WriteLine("Задание 2.2: Реализация очереди\n");
            string inputFileLine = ReadFile("input.txt");
            DoOperation(inputFileLine);
        }

        private static string ReadFile(string fileName) => File.ReadAllText($"..\\..\\..\\..\\{fileName}");

        private static void DoOperation(string operationNumber)
        {
            Queue<string> queue = new();
            List<string> numbers = operationNumber.Split(" ").ToList().Where(x => !x.Equals(string.Empty)).ToList();
            foreach (var num in numbers)
            {
                string currNum = num.Trim();

                if (num.Length > 1)
                {
                    string[] operation = currNum.Split(",");
                    ExecOperation(queue, operation[0], operation[1]);
                }
                else
                {
                    ExecOperation(queue, currNum);
                }
            }
        }

        private static void ExecOperation(Queue<string> queue, string operationNumber, string value = "")
        {
            switch (operationNumber)
            {
                case "1":
                    Console.WriteLine($"EnQueue: {value}");
                    queue.EnQueue(value);
                    break;
                case "2":
                    Console.WriteLine($"DeQueue: {queue.DeQueue()}");
                    break;
                case "3":
                    Console.WriteLine($"First: {queue.First()}");
                    break;
                case "4":
                    Console.WriteLine($"IsEmpty: {queue.IsEmpty()}");
                    break;
                case "5":
                    Console.Write("Print: ");
                    queue.List.Print();
                    break;
                default:
                    Console.WriteLine("error: такой команды не существует");
                    break;
            }
        }
    }
}
