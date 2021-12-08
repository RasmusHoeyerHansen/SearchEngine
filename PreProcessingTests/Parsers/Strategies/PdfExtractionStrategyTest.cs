using NUnit.Framework;
using PreProcessingTest.Common.Exceptions;
using PreProcessingTest.Parsing.Models;
using PreProcessingTest.Parsing.Parsers.Strategies;

namespace PreProcessingTest.Parsers.Strategies
{
    public class PdfExtractionStrategyTest
    {
        [Test]
        public void TryExtract_NullInput_ThrowsPdfParsingException()
        {
            var strategy = new PdfExtractionStrategy();
            Assert.Throws<PdfParsingException>(() => strategy.TryExtract(null, out _));
        }

        [Test]
        public void TryExtract_PdfWithNoText_ThrowsPdfParsingException()
        {
            var strategy = new PdfExtractionStrategy();
            Assert.Throws<PdfParsingException>(() => strategy.TryExtract(new PdfDocument("myPath"), out _));
        }

        [Test]
        public void TryExtract_PdfWithNullPath_ThrowsPdfParsingException()
        {
            var strategy = new PdfExtractionStrategy();
            Assert.Throws<PdfParsingException>(() => strategy.TryExtract(new PdfDocument(null), out _));
        }

        [Test]
        public void TryExtract_PdfWithEmptyPath_ThrowsPdfParsingException()
        {
            var strategy = new PdfExtractionStrategy();
            Assert.Throws<PdfParsingException>(() => strategy.TryExtract(new PdfDocument(string.Empty), out _));
        }
    }
}