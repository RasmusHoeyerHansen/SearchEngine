using System;
using System.Collections.Generic;
using System.Linq;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.Preprocessing;
using KnowledgeExtraction.Preprocessing.Models;
using NUnit.Framework;

namespace ExtractorTests.PreprocessingTests
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
            IExtractor<PdfDocument, PdfArticle> pdfExtractor = new PdfArticleFactory();
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
            IExtractor<PdfDocument, PdfArticle> pdfExtractor = new PdfArticleFactory();
            PdfDocument document = CreateTestPDF(input);
            Assert.DoesNotThrow( () => pdfExtractor.Extract(document));
        }
        
        [Test]
        [TestCase("123 Hello there 123")]
        [TestCase("0 1 2 3")]
        [TestCase("æøå")]
        public void Parse_ReadFromFilePath_GivesTextFromFile(string input)
        {
            var pdfExtractor = new PdfArticleFactory();
            PdfDocument document = CreateTestPDF(input);
            IEnumerable<string> actual = pdfExtractor.Parse(document.Path)?.ParsedStrings;
            string[] expected = input.Split(" ");

            IEnumerable<string> enumerable = (string[]) actual;
            Assert.NotNull(enumerable);
            Assert.AreEqual(expected.Count(), enumerable.Count());
            CollectionAssert.AreEqual(expected, enumerable, StringComparer.Ordinal);
        }

        
        [Test]
        public void Parse_ReturnsArticleWithStringFromPDF_WithTables_IsNotEmpty()
        {
            var pdfExtractor = new PdfArticleFactory();
            PdfDocument input = CreateTestPDF(ReadPdf());
            PdfArticle q = null; 
            
            Assert.DoesNotThrow(()=> q = pdfExtractor.Extract(input));
            Assert.IsNotNull(q);
            Assert.IsNotEmpty(q.ParsedStrings);
        }
        
        [Test]
        public void Parse_ReturnsObjectWithAllFieldsSet()
        {
            var pdfExtractor = new PdfArticleFactory();
            PdfDocument input = CreateTestPDF("string");
            PdfArticle result = pdfExtractor.Extract(input);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Path);
            Assert.IsNotNull(result.Title);
            Assert.IsNotNull(result.ParsedStrings);
            
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Title);
            Assert.IsNotEmpty(result.ParsedStrings);
        }
    }
}