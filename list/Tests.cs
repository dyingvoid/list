using System;
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
            CreateFile();
            string inputFileLine = ReadFile("testfile.txt");
            _file = inputFileLine.Split(' ');
            Test(inputFileLine);
        }

        public static string[]? _file;

        private static string ReadFile(string fileName) => File.ReadAllText($"..\\..\\..\\..\\{fileName}");

        private static void CreateFile()
        {
            Random random = new();
            random.Next(1, 5);
            StringBuilder stringBuilder = new();
            for (int i = 0; i <= 100; i++)
            {
                int item = random.Next(1, 5);
                if (item == 1)
                    stringBuilder.Append($"{item},{random.Next(0, 50)} ");
                else
                    stringBuilder.Append($"{item} ");
            }
            File.WriteAllText("..\\..\\..\\..\\testfile.txt", stringBuilder.ToString().Trim());
        }

        private static void Test(string line)
        {
            Stopwatch stopwatch = new();
            string results = "Количество операций;Время (миллисекунды)\n";
            double averageTime = 0;
            DateTime startTime = DateTime.Now;
            
            for (int elementsCount = 0; elementsCount < _file!.Length; elementsCount++)
            {
                for (int i = 0; i < 5; i++)
                {
                    stopwatch.Restart();
                    StackVisualisation stackVisualisation = new();
                    stopwatch.Stop();
                    CreateFile();
                    averageTime += stopwatch.Elapsed.TotalMilliseconds;
                }

                results += $"{elementsCount};{Math.Round(averageTime /= 5, 6)};\n";
                Console.WriteLine($"{elementsCount}");
            }
            
            DateTime finishTime = DateTime.Now;
            Console.WriteLine(finishTime - startTime);
            File.WriteAllText(Path.GetFullPath("./results.csv"), string.Empty);
            File.AppendAllText(Path.GetFullPath("./results.csv"), results);
        }
    }
}
