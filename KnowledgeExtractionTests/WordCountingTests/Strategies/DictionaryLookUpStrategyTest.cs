using System.Collections.Generic;
using System.Linq;
using KnowledgeExtraction.WordCounting;
using NSubstitute;
using NUnit.Framework;
using PreProcessing.Common;

namespace KnowledgeExtractionTests.WordCountingTests.Strategies
{
    public class DictionaryLookUpStrategyTest
    {
        [Test]
        [TestCase("a", "b", "engineering", "æ", "ø", "å")]
        public void ProcessMediaItem_AllFromInputItemIsInResultArray(params string[] inputStrings)
        {
            var item = Substitute.For<ITextItem>();
            item.ParsedStrings.Returns(inputStrings);
            var strategy = new DictionaryLookUpStrategy();

            IEnumerable<IWordCount> x = strategy.ProcessMedia(item);
            Assert.IsTrue(x.All(ratio => inputStrings.Contains(ratio.Word)));
        }

        [Test]
        [TestCase(1, "a")]
        [TestCase(1, "a", "a")]
        [TestCase(1, "a", "a", "a")]
        [TestCase(2, "b", "a")]
        [TestCase(3, "b", "a", "c")]
        [TestCase(4, "b", "a", "c", "d")]
        public void ProcessMediaItem_CreatesOnlyOneWordRatioPerWord(int numberOfUniqueWords, params string[] strings)
        {
            var item = Substitute.For<ITextItem>();
            item.ParsedStrings.Returns(strings);
            var strategy = new DictionaryLookUpStrategy();

            IEnumerable<IWordCount> x = strategy.ProcessMedia(item);
            IWordCount[] wordRatios = x as WordCount[] ?? x.ToArray();
            Assert.AreEqual(numberOfUniqueWords, wordRatios.Count());
        }


        [Test]
        [TestCase(1, 1, "b", "a")]
        [TestCase(1, 1, "a", "b")]
        [TestCase(3, 1, "a", "a", "a", "b")]
        [TestCase(2, 3, "b", "a", "a", "a", "b")]
        public void ProcessMediaItem_GivesCorrectWordCount(int firstWordCount, int secondWordCount,
            params string[] strings)
        {
            var item = Substitute.For<ITextItem>();
            item.ParsedStrings.Returns(strings);
            var strategy = new DictionaryLookUpStrategy();

            IEnumerable<IWordCount> x = strategy.ProcessMedia(item);
            IWordCount[] wordRatios = x as WordCount[] ?? x.ToArray();
            Assert.AreEqual(firstWordCount, wordRatios.First().Occurances);
            Assert.AreEqual(secondWordCount, wordRatios.Skip(1).First().Occurances);
        }
    }
}