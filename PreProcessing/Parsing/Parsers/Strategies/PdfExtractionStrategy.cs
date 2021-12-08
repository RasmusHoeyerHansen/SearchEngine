using System;
using System.IO;
using iTextSharp.text.pdf;
using PreProcessingTest.Common.Exceptions;
using PreProcessingTest.Parsing.Models;
using PreProcessingTest.Parsing.Parsers.Strategies.Abstractions;
using PdfDocument = PreProcessingTest.Parsing.Models.PdfDocument;

namespace PreProcessingTest.Parsing.Parsers.Strategies
{
    internal class PdfExtractionStrategy
        : DocumentTextReader, ITryExtractionStrategy<Models.PdfDocument, PdfArticle>
    {
        public virtual PdfArticle? ExecuteExtraction(Models.PdfDocument data)
        {
            string? text = ReadText(data.Path);
            string[]? strings = text.Split(" ");
            return new PdfArticle(text.Split(" "), DocumentTitle);
        }

        public virtual PdfArticle? ExecuteExtraction(string path)
        {
            string? text = ReadText(path);
            string[]? strings = text.Split(" ");
            return new PdfArticle(text.Split(" "), DocumentTitle);
        }

        public bool TryExtract(Models.PdfDocument documentStream, out PdfArticle? result)
        {
            try
            {
                result = ExecuteExtraction(documentStream);
                return true;
            }
            catch (IOException e)
            {
                result = default;
                throw new PdfParsingException(e.Message);
            }
            catch (NullReferenceException)
            {
                throw new PdfParsingException("Could not extract from PDF. Document was null.");
            }
            catch (PdfException)
            {
                throw new PdfParsingException("Document format not pdf.");
            }
        }
    }
}