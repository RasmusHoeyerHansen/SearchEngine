using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PreProcessing.Parsing.Models;
using PreProcessing.Parsing.Parsers.Strategies.Abstractions;

namespace PreProcessing.Parsing.Parsers.Strategies
{
    internal class ByteArrayExtractionStrategy : IExtractionStrategy<byte[], PdfArticle>
    {
        public PdfArticle? ExecuteExtraction(byte[] data)
        {
            string title;
            StringBuilder bob = new();
            using (PdfReader reader = new(data))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                    bob.Append(PdfTextExtractor.GetTextFromPage(reader, i,
                        new GlyphTextRenderListener(new LocationTextExtractionStrategy())));

                title = reader.Info["Title"];
                return new PdfArticle(bob.ToString().Split(" "), title);
            }
        }
    }
}