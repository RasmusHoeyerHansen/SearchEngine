using System.Runtime.CompilerServices;
using iTextSharp.text;

namespace KnowledgeExtraction.Preprocessing.Models
{
    public class PdfDocument : Document
    {
        public string Path { get; }

        public PdfDocument(string path, string title)
        {
            Title = title;
            Path = path;
        }

        public string Title { get; set; } = "";
    }
}