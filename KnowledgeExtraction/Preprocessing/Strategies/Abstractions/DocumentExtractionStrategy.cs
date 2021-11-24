

using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public abstract class DocumentExtractionStrategy<TResult> : ExtractionStrategy<Document, TResult>
    {
        protected readonly string Path;
        public string DocumentTitle { get; private set; }

        public DocumentExtractionStrategy(Document document, string path, string documentTitle) : base(document)
        {
            this.Path = path;
            DocumentTitle = documentTitle;
        }
        
        public DocumentExtractionStrategy(Document document, string path) : base(document)
        {
            this.Path = path;
            DocumentTitle = "";
        }
        

        protected override string ReadText()
        {
            StringBuilder bob = new StringBuilder();
            using (PdfReader reader = new PdfReader(Path))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    bob.Append(PdfTextExtractor.GetTextFromPage(reader, i,
                        new GlyphTextRenderListener(new LocationTextExtractionStrategy())));
                }
            }
            return bob.ToString();
        }
    }
}