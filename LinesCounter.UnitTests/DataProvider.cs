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
                ExpectedInvalidLines = new List<string>(),
                ExpectedMaxLines = new List<(float, string)>
                {
                    (71, "2, 32, 37")
                }
            }};

            yield return new object[] { new TestLineItem
            {
                Description = "Float set.",
                Input = new[] {
                    "1.1, 2.2, 3.3",
                    "0.1, -0.2, 0.3",
                    "0.2, 0.00032, 0.20037"
                },
                ExpectedInvalidLines = new List<string>(),
                ExpectedMaxLines = new List<(float, string)>
                {
                    (6.6f, "1.1, 2.2, 3.3")
                }
            }};

            yield return new object[] { new TestLineItem
            {
                Description = "Exp set.",
                Input = new[] {
                    "1.1E-1, 2.2E+2, 3.3E+10",
                    "-0.1E-2, -0.2E+2, 0.3",
                    "0.2E+20, 0.00032E+0, 0.20037"
                },
                ExpectedInvalidLines = new List<string>(),
                ExpectedMaxLines = new List<(float, string)>
                {
                    (2E+19f, "0.2E+20, 0.00032E+0, 0.20037")
                }
            }};

            yield return new object[] { new TestLineItem
            {
                Description = "All invalid set.",
                Input = new[] {
                    "1 ..1E-1, 2.2E+2, 3.3E+10",
                    "-0.1.E-2, -0.2E+2, 0.3",
                    "0.2E+20, 0.00-2032E+0, 0.20037"
                },
                ExpectedInvalidLines = new List<string>
                {
                    "1 ..1E-1, 2.2E+2, 3.3E+10",
                    "-0.1.E-2, -0.2E+2, 0.3",
                    "0.2E+20, 0.00-2032E+0, 0.20037"
                },
                ExpectedMaxLines = new List<(float, string)>()
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
                ExpectedInvalidLines = new List<string>(),
                ExpectedMaxLines = new List<(float, string)>
                {
                    (71, "2, 32, 37")
                }
            }};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TestLineItem
    {
        public string[] Input { get; set; }
        public string Description { get; set; }
        public List<(float, string)> ExpectedMaxLines { get; set; }
        public List<string> ExpectedInvalidLines { get; set; }
    }
}
