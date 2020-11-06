using System.Collections;
using System.Collections.Generic;

namespace LinesCounter.UnitTests
{
    public class DataProvider : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new TestLineItem
            {
                Description = "Integer set.",
                Input = new[] {
                "11, 22, 33",
                "1, 2, 3",
                "2, 32, 37"
                },
                ExpectedInvalidLinesNumbers = new List<int>(),
                ExpectedMaxLineNumbers = new List<int>{3}
            }};

            yield return new object[] { new TestLineItem
            {
                Description = "Float set.",
                Input = new[] {
                    "1.1, 2.2, 3.3",
                    "0.1, -0.2, 0.3",
                    "0.2, 0.00032, 0.20037"
                },
                ExpectedInvalidLinesNumbers = new List<int>(),
                ExpectedMaxLineNumbers = new List<int>{1}
            }};

            yield return new object[] { new TestLineItem
            {
                Description = "Exp set.",
                Input = new[] {
                    "1.1E-1, 2.2E+2, 3.3E+10",
                    "-0.1E-2, -0.2E+2, 0.3",
                    "0.2E+20, 0.00032E+0, 0.20037"
                },
                ExpectedInvalidLinesNumbers = new List<int>(),
                ExpectedMaxLineNumbers = new List<int>{3}
            }};

            yield return new object[] { new TestLineItem
            {
                Description = "All invalid set.",
                Input = new[] {
                    "1 ..1E-1, 2.2E+2, 3.3E+10",
                    "-0.1.E-2, -0.2E+2, 0.3",
                    "0.2E+20, 0.00-2032E+0, 0.20037"
                },
                ExpectedInvalidLinesNumbers = new List<int>{1,2,3},
                ExpectedMaxLineNumbers = new List<int>()
            }};

            yield return new object[] { new TestLineItem
            {
                Description = "Set with white spaces.",
                Input = new[] {
                    "11, 22, 33",
                    "",
                    "1, 2, 3",
                    "          ",
                    "2, 32, 37"
                },
                ExpectedInvalidLinesNumbers = new List<int>(),
                ExpectedMaxLineNumbers = new List<int>{5}
            }};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TestLineItem
    {
        public string[] Input { get; set; }
        public string Description { get; set; }
        public List<int> ExpectedMaxLineNumbers { get; set; }
        public List<int> ExpectedInvalidLinesNumbers { get; set; }
    }
}
