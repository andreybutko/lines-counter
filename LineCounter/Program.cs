using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace LinesCounter
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path;
            if (args.Length == 0)
            {
                Console.WriteLine("Enter source file path:");
                path = AskForPath();
            }
            else
            {
                path = args[0];
            }

            var service = new LinesService(new FileSystem());

            var (maxLineNumbers, invalidLines) = service.GetMaxLineNumbers(path);

            Print("TOP lines", maxLineNumbers);
            Print("Invalid lines", invalidLines);
        }

        private static void Print(string name, IList<int> numbers)
        {
            Console.WriteLine($"{name}:");

            var result = string.Join(',', numbers);
            Console.WriteLine(result);
        }

        private static string AskForPath()
        {
            try
            {
                var input = Console.ReadLine();
                var isValid = File.Exists(input);
                return isValid ? input : throw new ArgumentException();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong path, please try another one.");
                return AskForPath();
            }
        }
    }
}
