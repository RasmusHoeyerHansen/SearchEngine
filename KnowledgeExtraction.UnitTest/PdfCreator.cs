﻿

using System;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Path = System.IO.Path;
using PdfDocument = KnowledgeExtraction.Preprocessing.Models.PdfDocument;

namespace ExtractorTests
{
    public abstract class PdfCreator
    {
        protected virtual PdfDocument CreateTestPDF(string path, string text)
        {
            PdfDocument pdfDocument = new PdfDocument(path+ Path.DirectorySeparatorChar+"test.pdf");
            PdfWriter.GetInstance(pdfDocument,
                new FileStream(path, FileMode.Create));
            pdfDocument.Open( );
            pdfDocument.Add(new Paragraph(text));
            pdfDocument.AddTitle("TITLE");
            pdfDocument.Close( );
            
            return pdfDocument;
        }
        protected virtual PdfDocument CreateTestPDF(string text)
        {
            string path = @Directory.GetCurrentDirectory()+ Path.DirectorySeparatorChar+"test.pdf";
            
            PdfDocument pdfDocument = new PdfDocument(path);
            PdfWriter.GetInstance(pdfDocument,
                new FileStream(path, FileMode.Create));
            
            pdfDocument.Open( );
            pdfDocument.Add(new Paragraph(text));
            pdfDocument.AddTitle("TITLE");
            pdfDocument.Close( );
            
            return pdfDocument;
        }        
 
        

        protected string ReadPdf()
        {
            StringBuilder bob = new StringBuilder();
            using (PdfReader reader = new PdfReader(@"C:\Users\rasmus\Desktop\SearchEngine\KnowledgeExtraction.UnitTest\PDFs\Rasmus Høyer Hansen, grades - Aalborg University.pdf"))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    try
                    {
                        bob.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
            return bob.ToString();
        }
    }
}