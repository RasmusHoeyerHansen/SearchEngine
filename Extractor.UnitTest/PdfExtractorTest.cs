using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PdfExtractor;
using PDfExtractor.Models;
using PdfDocument = PDfExtractor.Models.PdfDocument;


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
            IExtractor<PdfDocument, PdfArticle> pdfExtractor = new PdfExtractor.PdfExtractor();
            IEnumerable<string> actual = pdfExtractor.Parse(CreateTestPDF(input)).ParsedStrings;
            IEnumerable<string> expected = input.Split(' ');

            IEnumerable<string> enumerable = actual as string[] ?? actual.ToArray();
            Assert.AreEqual(expected.Count(), enumerable.Count());
            CollectionAssert.AreEqual(expected, enumerable, StringComparer.Ordinal);
        }

        
        [Test]
        public void Extract_Returns_StringContainer_With_String_From_PDF_With_Tables_IsNotEmpty()
        {
            var pdfExtractor = new PdfExtractor.PdfExtractor();
            PdfDocument input = CreateTestPDF(ReadPdf());
            PdfArticle q = null; 
            
            Assert.DoesNotThrow(()=> q = pdfExtractor.Parse(input));
            Assert.IsNotNull(q);
            Assert.IsNotEmpty(q.ParsedStrings);
        }
    }
}