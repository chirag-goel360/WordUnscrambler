using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnScrambler.Helpers;

namespace WordUnScrambler.Test.Unit
{
    [TestClass]
    public class WordMatcherTest
    {
        private readonly WordMatcher _wordMatcher = new WordMatcher();
        [TestMethod]
        public void CheckScrambledWords()
        {
            string[] words = { "dog", "elephant", "monkey" };
            string[] scrambledWords = { "elhantep" };
            var matchedWords = _wordMatcher.Match(scrambledWords, words);
            Assert.IsTrue(matchedWords.Count == 1);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("elhantep"));
            Assert.IsTrue(matchedWords[0].Word.Equals("elephant"));
        }

        [TestMethod]
        public void CheckScrambledWords2()
        {
            string[] words = { "dog", "elephant", "monkey" };
            string[] scrambledWords = { "elhantep", "ogd" };
            var matchedWords = _wordMatcher.Match(scrambledWords, words);
            Assert.IsTrue(matchedWords.Count == 2);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("elhantep"));
            Assert.IsTrue(matchedWords[0].Word.Equals("elephant"));
            Assert.IsTrue(matchedWords[1].ScrambledWord.Equals("ogd"));
            Assert.IsTrue(matchedWords[1].Word.Equals("dog"));
        }
    }
}
