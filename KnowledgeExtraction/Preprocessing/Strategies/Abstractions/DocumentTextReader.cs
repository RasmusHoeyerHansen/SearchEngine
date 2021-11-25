using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace KnowledgeExtraction.Preprocessing.Strategies.Abstractions
{
    public abstract class DocumentTextReader<TResult>
    {
        public string DocumentTitle { get; protected set; }
        
        protected virtual string ReadText(string path)
        {
            StringBuilder bob = new StringBuilder();
            using (PdfReader reader = new PdfReader(path))
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
    }
}