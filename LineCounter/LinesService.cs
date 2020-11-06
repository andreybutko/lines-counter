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

        public (IList<int>, IList<int>) GetMaxLineNumbers(string path)
        {
            var lines = FileSystem.File.ReadLines(Path.GetFullPath(path))
                .ToList();

            var invalidLines = new List<int>();
            var calculatedLines = new List<(int, float, string)>();

            for (var i = 0; i < lines.Count; i++)
            {
                try
                {
                    var line = lines[i];
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var numbers = line.Split(',');
                    var sum = numbers.Sum(LinesUtility.ValidateFloatString);
                    calculatedLines.Add((i + 1, sum, line));
                }
                catch (ArgumentException)
                {
                    invalidLines.Add(i + 1);
                }
            }

            var maxvalue = calculatedLines.DefaultIfEmpty().Max(x => x.Item2);
            var result = calculatedLines
                .Where(l => l.Item2 == maxvalue)
                .Select(_ => _.Item1)
                .ToList();

            return (result, invalidLines);
        }
    }
}
