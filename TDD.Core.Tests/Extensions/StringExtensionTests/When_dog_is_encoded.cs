using Machine.Specifications;
using TDD.Core.Extensions;

namespace TDD.Core.Tests.Extensions.StringExtensionTests
{
    [Subject(typeof(StringExtensions), "Encode")]
    public class When_dog_is_encoded
    {
        private static string wordToEncode;
        private static string expectedEncodedWord;
        private static string actualEncodedWord;

        Establish context = () =>
        {
            wordToEncode = "dog";
            expectedEncodedWord = "d1g";
        };

        Because of = () =>
        {
            actualEncodedWord = wordToEncode.Encode();
        };

        It Should_encode_word_as_d1g = () =>
            actualEncodedWord.ShouldEqual(expectedEncodedWord);

    }
}
