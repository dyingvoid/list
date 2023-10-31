using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    public class StackVisualisation
    {
        public StackVisualisation()
        {
            var inputFileLine = ReadFile("\\input.txt");
            DoOperation(inputFileLine);
        }

        private static string ReadFile(string fileName) => File.ReadAllText("input.txt");

        private static void DoOperation(string operationNumber)
        {
            Stack<string> stack = new();
            List<string> numbers = operationNumber.Split(" ").ToList().Where(x => !x.Equals(string.Empty)).ToList();
            foreach (var num in numbers)
            {
                string currNum = num.Trim();

                if (num.Length > 1)
                {
                    string[] operation = currNum.Split(",");
                    ExecOperation(stack: stack, operationNumber: operation[0], value: operation[1]);
                }
                else
                {
                    ExecOperation(stack: stack, operationNumber: currNum);
                }
            }
        }

        private static void ExecOperation(Stack<string> stack, string operationNumber, string value = "")
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
                    Console.WriteLine($"Top {stack.Top()}");
                    break;
                case "4":
                    Console.WriteLine($"IsEmpty {stack.IsEmpty()}");
                    break;
                case "5":
                    Console.WriteLine("Print ");
                    stack.List.Print();
                    break;
                default:
                    throw new Exception("Invalid operation");
            }
        }
    }
}