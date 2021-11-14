
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using NUnit.Framework;
using PDfExtractor;
using PdfDocument = PDfExtractor.PdfDocument;

namespace ExtractorTests
{
    public class TextExtractorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("123 Hello there 123")]
        [TestCase("0 1 2 3")]
        [TestCase("æøå")]
        public void Extract_Returns_StringContainer_With_Strings_From_PDF(string input)
        {
            IExtractor pdfExtractor = new PdfExtractor();
            IEnumerable<string> actual = pdfExtractor.ParsePdf(CreateTestPDF(input)).ParsedStrings;
            IEnumerable<string> expected = input.Split(' ');

            IEnumerable<string> enumerable = actual as string[] ?? actual.ToArray();
            Assert.AreEqual(expected.Count(), enumerable.Count());
            CollectionAssert.AreEqual(expected, enumerable, StringComparer.Ordinal);
        }

        
        [Test]
        
        public void Extract_Returns_StringContainer_With_String_From_PDF_With_Tables_IsNotEmpty()
        {
            IExtractor pdfExtractor = new PdfExtractor();
            PdfDocument input =  CreateTestPDF(LoadTestPDF());
            PdfExtractResult q = null; 
            
            Assert.DoesNotThrow(()=> q = pdfExtractor.ParsePdf(input));
            Assert.IsNotNull(q);
            Assert.IsNotEmpty(q.ParsedStrings);
        }
        
        

        private PdfDocument CreateTestPDF(string text)
        {
            string path = @"C:\Users\rasmus\Desktop\New folder\SearchEngine\ExtractorTests\PDFs\file.txt";
            PdfDocument pdfDocument = new PdfDocument(path);
            PdfWriter.GetInstance(pdfDocument,
                new FileStream(path, FileMode.Create));
            
            pdfDocument.Open( );
            pdfDocument.Add(new Paragraph(text));
            pdfDocument.Close( );
            
            return pdfDocument;
        }
        
        private string LoadTestPDF()
        {
            StringBuilder bob = new StringBuilder();
            using (PdfReader reader = new PdfReader(Environment.CurrentDirectory + @"\PDFs\Rasmus Høyer Hansen, grades - Aalborg University.pdf"))
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