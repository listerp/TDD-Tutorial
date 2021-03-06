﻿using Machine.Specifications;
using TDD.Core.Extensions;

namespace TDD.Core.Tests.Extensions.StringExtensionTests
{
    [Subject(typeof(StringExtensions), "Encode")]
    public class When_or_is_encoded
    {
        private static string wordToEncode;
        private static string expectedEncodedWord;
        private static string actualEncodedWord;

        Establish context = () =>
        {
            wordToEncode = "or";
            expectedEncodedWord = "o0r";
        };

        Because of = () =>
            actualEncodedWord = wordToEncode.Encode();

        It Should_encode_word_as_o0r = () =>
            actualEncodedWord.ShouldEqual(expectedEncodedWord);
    }
}
