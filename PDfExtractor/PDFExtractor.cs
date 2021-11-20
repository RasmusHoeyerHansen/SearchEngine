using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PDfExtractor.Models;
using PDfExtractor.Strategies;
using PdfDocument = PDfExtractor.Models.PdfDocument;

namespace PdfExtractor
{
    public class PdfExtractor : IPdfExtractor<ByteDocument>, IPdfExtractor<PdfDocument> 
    {
        public PdfArticle Parse(PdfDocument document)
        {
            return Parse(document, new DocumentExtractionStrategy(document, document.Path));
        }

        public PdfArticle Parse(PdfDocument document, IPdfExtractionStrategy strategy)
        {
            return new PdfArticle(strategy.ExecuteStrategy().Split(" "));
        }

        public PdfArticle Parse(ByteDocument document)
        {
            return Parse(document, new ByteArrayExtractionStrategy(document));
        }
        
        public PdfArticle Parse(ByteDocument document, IPdfExtractionStrategy strategy)
        {
            return new PdfArticle(strategy.ExecuteStrategy().Split(" "));
        }
    }

    public class TryExtractor : PdfException
    {
        
    } 
    
}