using System.IO;
using KnowledgeExtraction.Common;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Preprocessing;
using KnowledgeExtraction.Preprocessing.Parsers.Strategies;
using KnowledgeExtraction.Preprocessing.Parsers.Strategies.Abstractions;
using NUnit.Framework;

namespace ExtractorTests.KnowledgeExtraction.PreprocessingTests.Parsers.Strategies
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