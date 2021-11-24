
using System;
using System.Collections.Generic;
using System.Linq;
using Domain_models.Models;
using KnowledgeExtraction.Preprocessing;
using KnowledgeExtraction.Preprocessing.Models;
using NUnit.Framework;

namespace ExtractorTests
{
    public class PdfExtractorTest : PdfCreator
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("123 Hello there 123")]
        [TestCase("0 1 2 3")]
        [TestCase("æøå")]
        public void Extract_Returns_StringContainer_With_Strings_From_PDF(string input)
        {
            IExtractor<PdfDocument, PdfArticle> pdfExtractor = new PdfArticleFactory();
            IEnumerable<string> actual = pdfExtractor.Parse(CreateTestPDF(input)).ParsedStrings;
            IEnumerable<string> expected = input.Split(' ');

            IEnumerable<string> enumerable = actual as string[] ?? actual.ToArray();
            Assert.AreEqual(expected.Count(), enumerable.Count());
            CollectionAssert.AreEqual(expected, enumerable, StringComparer.Ordinal);
        }

        
        [Test]
        public void Extract_Returns_StringContainer_With_String_From_PDF_With_Tables_IsNotEmpty()
        {
            var pdfExtractor = new PdfArticleFactory();
            PdfDocument input = CreateTestPDF(ReadPdf());
            PdfArticle q = null; 
            
            Assert.DoesNotThrow(()=> q = pdfExtractor.Parse(input));
            Assert.IsNotNull(q);
            Assert.IsNotEmpty(q.ParsedStrings);
        }
    }
}