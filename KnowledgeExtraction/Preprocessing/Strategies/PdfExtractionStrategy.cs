using System;
using System.IO;
using System.Reflection.Metadata;
using Domain_models.Exceptions;
using iTextSharp.text.pdf;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.Preprocessing.Strategies.Abstractions;
using PdfDocument = KnowledgeExtraction.Preprocessing.Models.PdfDocument;

namespace KnowledgeExtraction.Preprocessing.Strategies
{
    internal class PdfExtractionStrategy 
        : DocumentTextReader<Document>, ITryExtractionStrategy<PdfDocument, PdfArticle>
    {
        public virtual PdfArticle? ExecuteExtraction(PdfDocument data)
        {
            string? text = ReadText(data.Path);
            string[]? strings = text.Split(" ");
            return new PdfArticle(text.Split(" "), data.Path, DocumentTitle);
        }
        
        public virtual PdfArticle? ExecuteExtraction(string path)
        {
            string? text = ReadText(path);
            string[]? strings = text.Split(" ");
            return new PdfArticle(text.Split(" "), path, DocumentTitle);
        }

        public bool TryExtract(PdfDocument inputDocument, out PdfArticle? result)
        {
            try
            {
                result = ExecuteExtraction(inputDocument);
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