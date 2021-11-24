using Domain_models.Models;
using iTextSharp.text;
using KnowledgeExtraction.Preprocessing.Strategies.Abstractions;

namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public class PdfExtractionStrategy : DocumentExtractionStrategy<PdfArticle>
    {
        public override PdfArticle ExecuteExtraction(Document d)
        {
            string? text = ReadText();
            return new PdfArticle(text.Split(" "), Path, DocumentTitle);
        }
    }
}