using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PdfExtractor
{
    public class PdfExtractor : IExtractor
    {
        public PdfArticle ParsePdf(PdfDocument document)
        {
            string result;
            IPdfExtractionStrategy strategy = new DocumentExtractionStrategy(document, document.Path);
            return new PdfArticle(strategy.ExtractText().Split(" "));
        }

        public PdfArticle ParsePdf(byte[] documentBytes)
        {
            
        }
        

    }
}