using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace KnowledgeExtraction.Preprocessing.Strategies.Abstractions
{
    public abstract class DocumentExtractionStrategy<TResult> : IExtractionStrategy<Document, TResult>
    {
        protected readonly string Path;
        public string DocumentTitle { get; protected set; }
        

        protected string ReadText()
        {
            StringBuilder bob = new StringBuilder();
            using (PdfReader reader = new PdfReader(Path))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    bob.Append(PdfTextExtractor.GetTextFromPage(reader, i,
                        new GlyphTextRenderListener(new LocationTextExtractionStrategy())));
                }

                DocumentTitle=reader.Info["Title"];
            }
            return bob.ToString();
        }

        public abstract TResult? ExecuteExtraction(Document data);
    }
}