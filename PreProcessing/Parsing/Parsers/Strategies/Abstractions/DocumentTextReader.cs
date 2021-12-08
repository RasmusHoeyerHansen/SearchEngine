using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PreProcessingTest.Parsing.Parsers.Strategies.Abstractions
{
    internal abstract class DocumentTextReader
    {
        public string DocumentTitle { get; protected set; }

        protected virtual string ReadText(string path)
        {
            StringBuilder bob = new();
            using (PdfReader reader = new(path))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                    bob.Append(PdfTextExtractor.GetTextFromPage(reader, i,
                        new GlyphTextRenderListener(new LocationTextExtractionStrategy())));
                DocumentTitle = reader.Info["Title"];
            }

            return bob.ToString();
        }
    }
}