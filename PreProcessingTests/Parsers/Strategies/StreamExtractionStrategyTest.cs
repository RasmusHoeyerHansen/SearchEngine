using System.IO;
using NUnit.Framework;
using PreProcessing.Common;
using PreProcessing.Common.Exceptions;
using PreProcessing.Parsing.Parsers.Strategies;
using PreProcessing.Parsing.Parsers.Strategies.Abstractions;

namespace ExtractorTests.PreProcessingTests.Parsers.Strategies
{
    public class StreamExtractionStrategyTest
    {
        [Test]
        public void TryExtract_NullInput_ThrowsPdfParsingException()
        {
            ITryExtractionStrategy<Stream, ITextItem> strategy = new StreamExtractionStrategy();

            Assert.Throws<PdfParsingException>(() => strategy.TryExtract(null, out _));
        }

        [Test]
        public void TryExtract_PdfWithNoText_ThrowsPdfParsingException()
        {
            ITryExtractionStrategy<Stream, ITextItem> strategy = new StreamExtractionStrategy();

            Assert.Throws<PdfParsingException>(() => strategy.TryExtract(CreateStream(), out _));
        }

        [Test]
        public void TryExtract_PdfWithNullPath_ThrowsPdfParsingException()
        {
            ITryExtractionStrategy<Stream, ITextItem> strategy = new StreamExtractionStrategy();

            Assert.Throws<PdfParsingException>(() => strategy.TryExtract(CreateStream(), out _));
        }

        [Test]
        public void TryExtract_PdfWithEmptyPath_ThrowsPdfParsingException()
        {
            ITryExtractionStrategy<Stream, ITextItem> strategy = new StreamExtractionStrategy();

            Assert.Throws<PdfParsingException>(() => strategy.TryExtract(CreateStream(), out _));
        }

        public static Stream CreateStream()
        {
            //Setup mock file using a memory stream
            string content = "Hello World from a Fake stream";
            string fileName = "test.pdf";
            Stream ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            return ms;
        }
    }
}