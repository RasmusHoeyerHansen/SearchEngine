

using iTextSharp.text;

namespace PDfExtractor
{
    public interface IExtractor
    {
        public PdfExtractResult ParsePdf(PdfDocument document);
    }
}