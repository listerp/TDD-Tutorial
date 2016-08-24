using System.Linq;

namespace TDD.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Encode(this string stringToEncode)
        {
            if (stringToEncode.Length <= 1)
                return stringToEncode;

            var firstLetter = stringToEncode.First();
            var lastLetter = stringToEncode.Last();
            var middleLetters = stringToEncode.Skip(1).Take(stringToEncode.Length - 2);
            var distinctLetters = middleLetters.Distinct();

            var encodedValue = $"{firstLetter}{distinctLetters.Count()}{lastLetter}";

            return encodedValue;
        }
    }
}
