using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public class DocumentExtractionStrategy : TryExtractionStrategy<Document>
    {
        public readonly string Path;
        public DocumentExtractionStrategy(Document document, string path) : base(document)
        {
            this.Path = path;
        }

        public override string ExecuteExtraction()
        {
            StringBuilder bob = new StringBuilder();
            using (PdfReader reader = new FdfReader(Path))
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