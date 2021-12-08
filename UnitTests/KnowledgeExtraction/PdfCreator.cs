using System;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Path = System.IO.Path;
using PdfDocument = PreProcessing.Parsing.Models.PdfDocument;

namespace ExtractorTests.KnowledgeExtraction
{
    public abstract class PdfCreator
    {
        internal virtual PdfDocument CreateTestPDF(string FullPathToFile, string text)
        {
            var pdfDocument = new PdfDocument(FullPathToFile);
            PdfWriter.GetInstance(pdfDocument,
                new FileStream(FullPathToFile, FileMode.Create));
            pdfDocument.Open();
            pdfDocument.Add(new Paragraph(text));
            pdfDocument.AddTitle("TITLE");
            pdfDocument.Close();

            return pdfDocument;
        }


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


        internal string ReadPdf()
        {
            var bob = new StringBuilder();
            using (var reader =
                new PdfReader(
                    @"C:\Users\rasmus\Desktop\SearchEngine\UnitTests\PDFs\Rasmus Høyer Hansen, grades - Aalborg University.pdf"))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                    try
                    {
                        bob.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
            }

            return bob.ToString();
        }
    }
}