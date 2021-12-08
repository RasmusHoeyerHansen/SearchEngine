using iTextSharp.text;

namespace PreProcessing.Parsing.Models
{
    internal class PdfDocument : Document
    {
        public string Path { get; }

        public PdfDocument(string path)
        {
            Path = path;
        }
    }
}