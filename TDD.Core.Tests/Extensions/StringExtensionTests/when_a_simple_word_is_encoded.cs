using Machine.Specifications;
using TDD.Core.Extensions;


namespace TDD.Core.Tests.Extensions.StringExtensionTests
{
    [Subject(typeof(StringExtensions))]
    public class when_a_simple_word_is_encoded
    {
        private static string wordToEncode;
        private static string expectedEncodedWord;
        private static string actualEncodedWord;

        Establish context = () =>
        {
            wordToEncode = "Dog";
            expectedEncodedWord = "D1g";
        };

        Because of = () =>
        {
            actualEncodedWord = wordToEncode.Encode();
        };

        It should_set_actualEncodedWord_to_D1g = () =>
            actualEncodedWord.ShouldEqual(expectedEncodedWord);

    }
}
