


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;


namespace PDfExtractor
{
    public class PdfExtractor : IExtractor
    {
        public PdfExtractResult ParsePdf(PdfDocument document)
        {
            string result;
            using (PdfReader reader = new PdfReader(document.Path))
            {
                ExtractPages(reader, out result);
            }
            
            return new PdfExtractResult(result.Split(" "));
        }

        private void ExtractPages(PdfReader reader, out string content)
        {
            StringBuilder bob = new StringBuilder();
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                try
                {
                    bob.Append(PdfTextExtractor.GetTextFromPage(reader, i, new GlyphTextRenderListener(new LocationTextExtractionStrategy())));
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            content = bob.ToString();
        }
    }
}