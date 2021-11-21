
using Domain.Models;
using PDfExtractor.Strategies;
using PdfDocument = PDfExtractor.Models.PdfDocument;

namespace PdfExtractor
{
    public class PdfArticleFactory : IPdfFactory<ByteDocument>, IPdfFactory<PdfDocument> 
    {
        public PdfArticle Parse(PdfDocument document)
        {
            return Parse(document, new DocumentExtractionStrategy(document, document.Path));
        }

        public PdfArticle Parse(PdfDocument document, IPdfExtractionStrategy strategy)
        {
            return new PdfArticle(strategy.ExecuteExtraction().Split(" "), document.Path);
        }

        public PdfArticle Parse(ByteDocument document)
        {
            return Parse(document, new ByteArrayExtractionStrategy(document));
        }
        
        public PdfArticle Parse(ByteDocument document, IPdfExtractionStrategy strategy)
        {
            return new PdfArticle(strategy.ExecuteExtraction().Split(" "), document.Path);
        }
    }
}