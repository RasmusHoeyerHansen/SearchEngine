using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PdfExtractor;

namespace PDfExtractor.Strategies
{
    public class ByteArrayExtractionStrategy : TryExtractionStrategy<byte[]>
    {
        public ByteArrayExtractionStrategy(ByteDocument document) : base(document.Bytes)
        {
            this.Path = document.Path;
        }

        public string Path { get; set; }

        public override string ExecuteStrategy()
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