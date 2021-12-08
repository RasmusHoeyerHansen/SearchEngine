using System;
using System.Collections.Generic;
using System.Linq;
using KnowledgeExtraction.Common;
using NUnit.Framework;
using PreProcessing.Parsing.Models;
using PreProcessing.Parsing.Parsers;

namespace ExtractorTests.KnowledgeExtraction.PreprocessingTests.Parsers
{
    public class PdfArticleFactoryTest : PdfCreator
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("123 Hello there 123")]
        [TestCase("0 1 2 3")]
        [TestCase("æøå")]
        public void Parse_Returns_StringContainer_With_Strings_From_PDF(string input)
        {
            ITextItemFactory<PdfDocument> pdfExtractor = new TextItemFactory();
            IEnumerable<string> actual = pdfExtractor.Extract(CreateTestPDF(input)).ParsedStrings;
            IEnumerable<string> expected = input.Split(' ');

            IEnumerable<string> enumerable = actual as string[];
            Assert.AreEqual(expected.Count(), enumerable.Count());
            CollectionAssert.AreEqual(expected, enumerable, StringComparer.Ordinal);
        }

        [Test]
        [TestCase("123 Hello there 123")]
        [TestCase("0 1 2 3")]
        [TestCase("æøå")]
        public void Parse_ReadFromFilePath_DoesNotThrow(string input)
        {
            ITextItemFactory<PdfDocument> pdfExtractor = new TextItemFactory();
            var document = CreateTestPDF(input);
            Assert.DoesNotThrow(() => pdfExtractor.Extract(document));
        }

        [Test]
        [TestCase("123 Hello there 123")]
        [TestCase("0 1 2 3")]
        [TestCase("æøå")]
        public void Parse_ReadFromFilePath_GivesTextFromFile(string input)
        {
            var pdfExtractor = new TextItemFactory();
            var document = CreateTestPDF(input);
            IEnumerable<string> actual = pdfExtractor.Parse(document.Path)?.ParsedStrings;
            string[] expected = input.Split(" ");

            IEnumerable<string> enumerable = (string[]) actual;
            Assert.NotNull(enumerable);
            Assert.AreEqual(expected.Count(), enumerable.Count());
            CollectionAssert.AreEqual(expected, enumerable, StringComparer.Ordinal);
        }

        [Test]
        public void Parse_ReturnsObjectWithAllFieldsSet()
        {
            var pdfExtractor = new TextItemFactory();
            var input = CreateTestPDF("string");
            var result = pdfExtractor.Extract(input);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Title);
            Assert.IsNotNull(result.ParsedStrings);

            Assert.IsNotEmpty(result.Title);
            Assert.IsNotEmpty(result.ParsedStrings);
        }
    }
}