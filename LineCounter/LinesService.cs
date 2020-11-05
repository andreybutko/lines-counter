using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;

namespace LinesCounter
{
    public class LinesService
    {
        private IFileSystem FileSystem { get; }

        public LinesService(IFileSystem fileSystem)
        {
            FileSystem = fileSystem;
        }

        public (IList<(float, string)>, IList<string>) GetMaxStringSum(string path)
        {
            var lines = FileSystem.File.ReadLines(Path.GetFullPath(path))
                .ToList();

            var invalidLines = new List<string>();
            var calculatedLines = new List<(float, string)>();

            foreach (var line in lines)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var numbers = line.Split(',');
                    var sum = numbers.Sum(LinesUtility.ValidateFloatString);
                    calculatedLines.Add((sum, line));
                }
                catch (ArgumentException)
                {
                    invalidLines.Add(line);
                }
            }

            var maxvalue = calculatedLines.Max(x => x.Item1);
            var result = calculatedLines.Where(l => l.Item1 == maxvalue).ToList();

            return (result, invalidLines);
        }
    }
}
