using System.Linq;

namespace TDD.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Encode(this string stringToEncode)
        {
            var firstLetter = stringToEncode.First();
            var lastLetter = stringToEncode.Last();
            var middleLetters = stringToEncode.Skip(1).Take(stringToEncode.Length - 2);

            var encodedValue = $"{firstLetter}{middleLetters.Count()}{lastLetter}";

            return encodedValue;
        }
    }
}
