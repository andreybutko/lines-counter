using System;
using System.Globalization;

namespace LinesCounter
{
    public static class LinesUtility
    {
        public static float ValidateFloatString(string number)
        {
            var isValid = float.TryParse(number, NumberStyles.Float, new NumberFormatInfo(), out float result);

            return isValid
                ? result
                : throw new ArgumentException();
        }
    }
}
