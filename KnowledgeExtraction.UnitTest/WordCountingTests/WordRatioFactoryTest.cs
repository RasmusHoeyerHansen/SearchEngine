using System.Collections.Generic;
using System.Linq;
using Domain_models.Entities;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.WordCounting;
using NSubstitute;
using NUnit.Framework;

namespace ExtractorTests.WordCountingTests
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
            ITextMediaItem item = Substitute.For<ITextMediaItem>();
            item.ParsedStrings.Returns(inputStrings);
            WordRatioFactory factory = new WordRatioFactory();
            IEnumerable<WordRatio> wordRatios = factory.Create(item);
            Assert.AreEqual(uniqueWords, wordRatios.Count());
        }

        [Test]
        public void ExecutesStrategyCorrectly_GivesCallToStrategy()
        {
            List<string> strings = new() {"string1", "string2"};
            WordRatioFactory factory = new WordRatioFactory();
            ITextMediaItem item = Substitute.For<ITextMediaItem>();
            IMediaItemProcessingStrategy<WordRatio> strategy =
                Substitute.For<IMediaItemProcessingStrategy<WordRatio>>();
            item.ParsedStrings.Returns(strings.ToArray());
            factory.Create(item, strategy);
            strategy.Received().ProcessMedia(item);
        }
    }
}
