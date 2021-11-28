using iTextSharp.text;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.Preprocessing.Strategies.Abstractions;

namespace KnowledgeExtraction.Preprocessing.Strategies
{
    internal abstract class DocumentExtractionStrategy<T> :
        DocumentTextReader<Document>, IExtractionStrategy<Document, PdfArticle>,
        ITryExtractionStrategy<Document, PdfArticle>
        where T : Document
    {
        protected readonly string Path;

        protected DocumentExtractionStrategy(string path)
        {
            Path = path;
        }
        public PdfArticle ExecuteExtraction(Document d)
        {
            string? text = ReadText(Path);
            return new PdfArticle(text.Split(" "), Path, DocumentTitle);
        }

        public bool TryExtract(Document inputDocument, out PdfArticle result)
        {
            try
            {
                result = ExecuteExtraction(inputDocument);
                return true;
            }
            catch
            {
                // ignored
                result = default;
                return false;
            }
        }
    }
}