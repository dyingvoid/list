using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    class QueueCSharp
    {
        public QueueCSharp(string path) 
        {
            string file = ReadFile(path);
            DoOperation(file);
        }

        private static string ReadFile(string fileName) => File.ReadAllText($"..\\..\\..\\files\\{fileName}");

        private static void DoOperation(string operationNumber)
        {
            Queue queue = new();
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

        private static void ExecOperation(Queue queue, string operationNumber, string value = "")
        {
            switch (operationNumber)
            {
                case "1":
                    Console.WriteLine($"EnQueue {value}");
                    queue.Enqueue(value);
                    break;
                case "2":
                    Console.WriteLine($"DeQueue {queue.Dequeue()}");
                    break;
                case "3":
                    Console.WriteLine($"First {queue.Peek()}");
                    break;
                default:
                    Console.WriteLine("error: такой команды не существует");
                    break;
            }
        }
    }
}
