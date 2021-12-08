using System.Collections.Generic;
using System.Linq;
using KnowledgeExtraction.WordCounting;
using NSubstitute;
using NUnit.Framework;
using PreProcessing.Common;

namespace KnowledgeExtractionTests.WordCountingTests
{
    public class WordRatioFactoryTest
    {
        [Test]
        [TestCase(1, "a")]
        [TestCase(1, "a", "a")]
        [TestCase(1, "a", "a", "a")]
        [TestCase(2, "b", "a")]
        [TestCase(3, "b", "a", "c")]
        [TestCase(4, "b", "a", "c", "d")]
        public void Test(int uniqueWords, params string[] inputStrings)
        {
            var item = Substitute.For<ITextItem>();
            item.ParsedStrings.Returns(inputStrings);
            var factory = new WordCountingFactory();
            IEnumerable<IWordCount> wordRatios = factory.CountWords(item);
            Assert.AreEqual(uniqueWords, wordRatios.Count());
        }

        [Test]
        public void ExecutesStrategyCorrectly_GivesCallToStrategy()
        {
            List<string> strings = new() {"string1", "string2"};
            var factory = new WordCountingFactory();
            var item = Substitute.For<ITextItem>();
            IMediaItemProcessingStrategy<WordCount> strategy =
                Substitute.For<IMediaItemProcessingStrategy<WordCount>>();
            item.ParsedStrings.Returns(strings.ToArray());
            factory.Create(item, strategy);
            strategy.Received().ProcessMedia(item);
        }
    }
}