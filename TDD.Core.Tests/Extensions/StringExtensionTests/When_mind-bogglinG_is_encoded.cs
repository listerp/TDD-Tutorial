using Machine.Specifications;
using TDD.Core.Extensions;

namespace TDD.Core.Tests.Extensions.StringExtensionTests
{
    [Subject(typeof(StringExtensions), "Encode")]
    public class When_mind_bogglinG_is_encoded
    {
        private static string wordToEncode;
        private static string expectedEncodedWord;
        private static string actualEncodedWord;

        Establish context = () =>
        {
            wordToEncode = "mind-BogglinG";
            expectedEncodedWord = "m8G";
        };

        Because of = () =>
            actualEncodedWord = wordToEncode.Encode();

        It Should_encode_word_as_m8G = () =>
            actualEncodedWord.ShouldEqual(expectedEncodedWord);
    }
}
