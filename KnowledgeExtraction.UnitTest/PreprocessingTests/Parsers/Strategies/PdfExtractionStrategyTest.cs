﻿using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Preprocessing.Models;
using KnowledgeExtraction.Preprocessing.Parsers.Strategies;
using NUnit.Framework;

namespace ExtractorTests.PreprocessingTests.Parsers.Strategies
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