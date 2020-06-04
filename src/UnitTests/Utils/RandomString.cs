using System;
using System.Text;

namespace UnitTests.Utils
{
    public static class RandomString
    {
        public static string NewSring(int length = 8) {
            var stringBuilder = new StringBuilder();
            var random = new Random();

            char letter;
            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                stringBuilder.Append(letter);
            }

            return stringBuilder.ToString();
        }
    }
}
