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
            Console.WriteLine("Задание 1.2: Реализация стека\n");
            string fileForTask2 = ReadFile("input.txt");
            DoOperation(fileForTask2);

            Console.WriteLine("\nЗадание 1.4: Вычисление выражения, записанного в постфиксной записи\n");
            string fileForTask45 = ReadFile("input2.txt");
            string inf = ParseInRPN(fileForTask45);
            List<string> operation = inf.Split(" ").ToList().Where(x => !x.Equals(string.Empty)).ToList();
            Console.WriteLine($"{fileForTask45} = {ParseInRPN(fileForTask45)} = {CalculateRPN(operation)}");
        }

        // Для тестов
        public StackVisualisation(string path)
        {
            string file = ReadFile(path);
            DoOperation(file);
        }

        private static string ReadFile(string fileName) => File.ReadAllText($"..\\..\\..\\files\\{fileName}");

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
                    ExecOperation(stack, operation[0], operation[1]);
                }
                else
                {
                    ExecOperation(stack, currNum);
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
                    Console.WriteLine("error: такой команды не существует");
                    break;
            }
        }

        public static string ParseInRPN(string input)
        {
            string stringRPN = string.Empty;
            Stack<char> stack = new();

            for (int i = 0; i < input.Length; i++)
            {

                if (Char.IsDigit(input[i]))
                {
                    while  (!IsOperation(input[i]))
                    {
                        stringRPN += input[i];
                        i++;

                        if (i == input.Length) break;
                    }

                    stringRPN += " ";
                    i--;
                }

                if (IsOperation(input[i]))
                {
                    if (input[i] == '(')
                        stack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        char s = (char)stack.Pop();

                        while (s != '(')
                        {
                            stringRPN += s.ToString() + ' ';
                            s = (char)stack.Pop();
                        }
                    }
                    else
                    {
                        if (stack.List.Head != null)
                            if (GetPriority(input[i]) <= GetPriority(stack.List.Head.Data))
                                stringRPN += stack.Pop().ToString() + " ";

                        stack.Push(char.Parse(input[i].ToString()));
                    }
                }
            }

            while (stack.List.Head != null)
                stringRPN += (char)stack.Pop() + " ";

            return stringRPN;
        }

        private static byte GetPriority(char s)
        {
            return s switch
            {
                '(' => 0,
                ')' => 1,
                '+' => 2,
                '-' => 3,
                '*' => 4,
                '/' => 4,
                '^' => 5,
                _ => 6,
            };
        }

        private static bool IsOperation(char symbol) => "+-/*^()".IndexOf(symbol) != -1;

        private static double CalculateRPN(List<string> rpn)
        {
            if (rpn.Count == 0)
                throw new ArgumentException("error: нет выражения");

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
                    if (calc.List.Head.Next == null)
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
                    throw new ArgumentException("error: непонятное число");
            }

            return calc.Pop();
        }

        private static double CalculateOperation(double first, string operation, double second = 0)
        {
            return operation switch
            {
                "+" => first + second,
                "-" => first - second,
                "/" => first / second,
                "*" => first * second,
                "ln" => Math.Log(first),
                "cos" => Math.Cos(first),
                "^" => Math.Pow(first, second),
                _ => throw new Exception("error: такой операции не существует"),
            };
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