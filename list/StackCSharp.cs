using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    class StackCSharp
    {
        public StackCSharp(string path) 
        {
            string file = ReadFile(path);
            DoOperation(file);
        }

        private static string ReadFile(string fileName) => File.ReadAllText($"..\\..\\..\\files\\{fileName}");

        private static void DoOperation(string operationNumber)
        {
            Stack stack = new();
            List<string> numbers = operationNumber.Split(" ").ToList().Where(x => !x.Equals(string.Empty)).ToList();
            foreach (var num in numbers)
            {
                string currNum = num.Trim();

                if (num.Length > 1)
                {
                    string[] operation = currNum.Split(",");
                    ExecOperation(stack, operation[0], operation[1]);
                }
                else
                {
                    ExecOperation(stack, currNum);
                }
            }
        }

        private static void ExecOperation(Stack stack, string operationNumber, string value = "")
        {
            switch (operationNumber)
            {
                case "1":
                    Console.WriteLine($"Push {value}");
                    stack.Push(value);
                    break;
                case "2":
                    Console.WriteLine($"Pop {stack.Pop()}");
                    break;
                case "3":
                    Console.WriteLine($"Top {stack.Peek()}");
                    break;
                default:
                    Console.WriteLine("error: такой команды не существует");
                    break;
            }
        }
    }
}
