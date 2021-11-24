using Domain_models.Models;
using iTextSharp.text;

namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public class PdfExtractionStrategy : DocumentExtractionStrategy<PdfArticle>
    {
        public PdfExtractionStrategy(Document document, string path, string documentTitle) : base(document, path, documentTitle)
        {
        }
        public PdfExtractionStrategy(Document document, string path) : base(document, path)
        {
        }

        public override PdfArticle ExecuteExtraction()
        {
            string? text = ReadText();
            return new PdfArticle(text.Split(" "), Path, DocumentTitle);
        }
    }
}