using System;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PdfExtractor
{
    public class DocumentExtractionStrategy : ExtractionStrategy<Document>
    {
        public readonly string Path;
        public DocumentExtractionStrategy(Document document, string path) : base(document)
        {
            this.Path = path;
        }
        private void TryExtractText(PdfReader reader, StringBuilder bob, int i)
        {
            try
            {
                bob.Append(PdfTextExtractor.GetTextFromPage(reader, i,
                    new GlyphTextRenderListener(new LocationTextExtractionStrategy())));
            }
            catch (Exception)
            {
                // ignored
            }
        }
        public override string ExtractText()
        {
            StringBuilder bob = new StringBuilder();
            using (PdfReader reader = new PdfReader(Path))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    TryExtractText(reader, bob, i);
                }
            }
            return bob.ToString();
        }
    }
}