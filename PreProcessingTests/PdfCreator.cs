using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Path = System.IO.Path;
using PdfDocument = PreProcessing.Parsing.Models.PdfDocument;

namespace PreProcessingTests
{
    public abstract class PdfCreator
    {
        internal virtual PdfDocument CreateTestPDF(string text)
        {
            string path = @Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "test.pdf";

            var pdfDocument = new PdfDocument(path);
            PdfWriter.GetInstance(pdfDocument,
                new FileStream(path, FileMode.Create));

            pdfDocument.Open();
            pdfDocument.Add(new Paragraph(text));
            pdfDocument.AddTitle("TITLE");
            pdfDocument.Close();

            return pdfDocument;
        }
    }
}