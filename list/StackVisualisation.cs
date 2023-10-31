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
            //string inputFileLine = ReadFile("input.txt");
            //DoOperation(inputFileLine);

            string inputFileLine = ReadFile("input2.txt");
            List<string> operation = inputFileLine.Split(" ").ToList().Where(x => !x.Equals(string.Empty)).ToList();
            double result = CalculateRPN(operation);
            Console.WriteLine(result);
        }

        private static string ReadFile(string fileName) => File.ReadAllText($"..\\..\\..\\..\\{fileName}");

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

        private static double CalculateRPN(List<string> rpn)
        {
            if (rpn.Count == 0)
            {
                throw new ArgumentException("Invalid number of values");
            }

            Stack<double> calc = new();
            foreach (var element in rpn)
            {
                double.TryParse(element, out double doubleValue);
                if (doubleValue != 0)
                {
                    calc.Push(doubleValue);
                }
                else if (IsOperation(element))
                {
                    if (calc.Count() < 2)
                    {
                        double first = calc.Pop();
                        calc.Push(CalculateOperation(first: first, operation: element));
                    }
                    else
                    {
                        double second = calc.Pop();
                        double first = calc.Pop();

                        calc.Push(CalculateOperation(first: first, second: second, operation: element));
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid value");
                }
            }

            return calc.Pop();
        }

        private static double CalculateOperation(double first, string operation, double second = 0)
        {
            switch (operation)
            {
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                case "/":
                    return first / second;
                case "*":
                    return first * second;
                case "ln":
                    return Math.Log(first);
                case "cos":
                    return Math.Cos(first);
                case "^":
                    return Math.Pow(first, second);
                default:
                    throw new Exception("Invalid operation");
            }
        }

        private static bool IsOperation(string operation) => operation.Equals("+")
                                                             || operation.Equals("-")
                                                             || operation.Equals("=")
                                                             || operation.Equals("/")
                                                             || operation.Equals("*")
                                                             || operation.Equals("^")
                                                             || operation.Equals("ln")
                                                             || operation.Equals("cos");
    }
}