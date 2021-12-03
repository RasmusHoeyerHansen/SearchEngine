using System.Runtime.CompilerServices;
using iTextSharp.text;

namespace KnowledgeExtraction.Preprocessing.Models
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