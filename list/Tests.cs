using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    public class Tests
    {
        public Tests() 
        {
            WriteFile();
            Test();
        }

        private static int _elCount = default;

        // Записывает файл с рандомным кол-вом элементов
        private static void WriteFile()
        {
            Random random = new();
            random.Next(1, 5);
            StringBuilder stringBuilder = new();
            for (int i = 0; i <= random.Next(1, 100000); i++)
            {
                int item = random.Next(1, 5);
                if (item == 1)
                    stringBuilder.Append($"{item},{random.Next(0, 50)} ");
                else
                    stringBuilder.Append($"{item} ");
            }
            File.WriteAllText("..\\..\\..\\files\\testfile.txt", stringBuilder.ToString().Trim());
            string file = ReadFile("testfile.txt");
            List<string> operation = file.Split(" ").ToList().Where(x => !x.Equals(string.Empty)).ToList();
            _elCount = operation.Count;
        }

        // Считывает текстовый файл с командами в строку
        private static string ReadFile(string fileName) => File.ReadAllText($"..\\..\\..\\files\\{fileName}");

        // Создаёт csv файл для построения графика
        private static void Test()
        {
            Stopwatch stopwatch = new();
            string results = "Время (миллисекунды);элементы\n";
            double averageTime = 0;
            DateTime startTime = DateTime.Now;
            
            for (int elementsCount = 0; elementsCount < 1000; elementsCount++)
            {
                for (int i = 0; i < 5; i++)
                {
                    stopwatch.Restart();
                    //StackVisualisation stackVisualisation = new("testfile.txt");
                    //QueueVisualisation queueVisualisation = new("testfile.txt");
                    //StackCSharp stackCSharp = new("testfile.txt");
                    //QueueCSharp queueCSharp = new("testfile.txt");
                    stopwatch.Stop();
                    averageTime += stopwatch.Elapsed.TotalMilliseconds;
                }
                results += $"{Math.Round(averageTime /= 5, 6)};{_elCount}\n";
                Console.WriteLine($"{elementsCount}");
                WriteFile();
            }
            
            DateTime finishTime = DateTime.Now;
            Console.WriteLine(finishTime - startTime);
            File.WriteAllText("..\\..\\..\\files\\results.csv", string.Empty);
            File.AppendAllText("..\\..\\..\\files\\results.csv", results);
        }
    }
}
