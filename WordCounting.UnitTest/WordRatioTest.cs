using System.Collections.Generic;
using System.Linq;
using Domain_models.Entities;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.WordCounting;
using NUnit.Framework;

namespace WordCounting.UnitTest
{
    
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, "Engineering","Engineering" )]
        [TestCase( 1, "æøå","æøå", "æøå" )]
        [TestCase( 3, "1","2", "3" )]
        [TestCase( 1, "1","1", "1" )]
        [TestCase( 1, "0","0", "0" )]
        [TestCase( 1, "æøå","æøå", "æøå" )]
        [TestCase(1, "æøå","æøå", "æøå" )]
        [TestCase(2, "æøå","æøå", "æøå", "a" )]
        [TestCase(3, "a","æ", "å", "a" )]
        [TestCase(4, "my","name", "is", "superman")]
        [TestCase(1, "a", "a")]
        [TestCase(2, "æøå","æøå", "æøå", "a")]
        [TestCase( 8, "a","b","c","d","e","f","g","h")]
        public void WordRatioFactory_StandardStrategy_GivesCorrectNumberOfWordRatio(int numberOfWordRatio,  params string[] strings)
        {
            IMediaItemProcessor<WordRatio> factory = new WordRatioFactory();
            IEnumerable<WordRatio>? x = factory.Create(new PdfArticle(strings, "", ""));

            IEnumerable<WordRatio> wordRatios = x as WordRatio[] ?? x.ToArray();
            Assert.AreEqual(numberOfWordRatio,wordRatios.Count());
        }
        
        [Test]
        [TestCase(2,"engineer", "engineer")]
        [TestCase(1,"engineer")]
        [TestCase(3,"abc", "abc", "abc")]
        [TestCase(6,"abc", "abc", "abc","abc", "abc", "abc")]
        [TestCase(2,"abc", "abc", "abcabc")]
        public void WordRatioFactory_StandardStrategy_SingleWordGivesCorrectNumberOfOccurances(int occurances, params string[] strings )
        {
            PdfArticle article = new("","", strings);
            IMediaItemProcessor<WordRatio> factory = new WordRatioFactory();
            IEnumerable<WordRatio>? wordRatios = factory.Create(article);
            Assert.AreEqual(occurances,wordRatios.First().Occurances);
        }
        
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("\n")]
        [TestCase("", "")]
        [TestCase("", " ")]
        [TestCase("", "\t")]
        [TestCase("", "\n")]
        [TestCase(" ", "")]
        [TestCase(" ", " ")]
        [TestCase(" ", "\t")]
        [TestCase(" ", "\n")]
        [TestCase("\t", "")]
        [TestCase("\t", " ")]
        [TestCase("\t", "\t")]
        [TestCase("\t", "\n")]
        [TestCase("\n", "")]
        [TestCase("\n", " ")]
        [TestCase("\n", "\t")]
        [TestCase("\n", "\n")]
        public void WordRatioFactory_StandardStrategy_IgnoresWhiteSpace(params string[] strings )
        {
            PdfArticle article = new("","", strings);
            IMediaItemProcessor<WordRatio> factory = new WordRatioFactory();
            IEnumerable<WordRatio>? wordRatios = factory.Create(article);
            Assert.AreEqual(0,wordRatios.Count());
        }
        

        [Test]
        [TestCase(1, 2,"engineering","a","a")]
        [TestCase(1, 5,"æøå","a","a","a","a","a")]
        [TestCase(2, 1,"æøå", "æøå","a")]
        [TestCase(1, 2,"æøå","a", "a")]
        public void WordRatioFactory_StandardStrategy_MultipleWordsGiveCorrectCounts(int firstWordRepetitions, int secondWordRepetitions, params string[] strings)
        {
            PdfArticle article = new("","", strings);
            IMediaItemProcessor<WordRatio> factory = new WordRatioFactory();
            IEnumerable<WordRatio> wordRatios = factory.Create(article);
            IEnumerable<WordRatio> enumerable = wordRatios as WordRatio[] ?? wordRatios.ToArray();
            Assert.AreEqual(firstWordRepetitions, enumerable.First().Occurances);
            Assert.AreEqual(secondWordRepetitions, enumerable.Skip(1).First().Occurances);
        }
        
        

    }
}
