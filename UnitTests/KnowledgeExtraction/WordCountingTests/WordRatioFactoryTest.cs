using System.Collections.Generic;
using System.Linq;
using Domain_models.Entities;
using KnowledgeExtraction.Common;
using KnowledgeExtraction.WordCounting;
using NSubstitute;
using NUnit.Framework;

namespace ExtractorTests.KnowledgeExtraction.WordCountingTests
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
            ITextItem item = Substitute.For<ITextItem>();
            item.ParsedStrings.Returns(inputStrings);
            WordCountingFactory factory = new WordCountingFactory();
            var wordRatios = factory.ExtractKnowledge(item);
            Assert.AreEqual(uniqueWords, wordRatios.Count());
        }

        [Test]
        public void ExecutesStrategyCorrectly_GivesCallToStrategy()
        {
            List<string> strings = new() {"string1", "string2"};
            WordCountingFactory factory = new WordCountingFactory();
            ITextItem item = Substitute.For<ITextItem>();
            IMediaItemProcessingStrategy<WordCount> strategy =
                Substitute.For<IMediaItemProcessingStrategy<WordCount>>();
            item.ParsedStrings.Returns(strings.ToArray());
            factory.Create(item, strategy);
            strategy.Received().ProcessMedia(item);
        }
    }
}
