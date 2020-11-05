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
            var path = string.Empty;

            if (args.Length == 0)
            {
                Console.WriteLine("Enter source file path:");
                path = AskForPath();
            }

            var service = new LinesService(new FileSystem());

            var (maxLines, invalidLines) = service.GetMaxStringSum(path);

            PrintResults(maxLines, invalidLines);
        }

        private static void PrintResults(IList<(float, string)> maxLines, IList<string> invalidLines)
        {
            Console.WriteLine("Results:");
            if (maxLines.Count > 1)
            {
                Console.WriteLine("Wow, there are a few of them!");
            }

            foreach (var (sum, line) in maxLines)
            {
                Console.WriteLine($"Sum: {sum} Line: {line}");
            }

            Console.WriteLine("Invalid lines:");
            foreach (var line in invalidLines)
            {
                Console.WriteLine(line);
            }
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
