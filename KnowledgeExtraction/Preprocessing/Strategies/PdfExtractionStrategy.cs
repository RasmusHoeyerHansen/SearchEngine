using System;
using System.Reflection.Metadata;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.Preprocessing.Models;
using KnowledgeExtraction.Preprocessing.Strategies.Abstractions;

namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public class PdfExtractionStrategy 
        : DocumentTextReader<Document>, ITryExtractionStrategy<PdfDocument, PdfArticle>
    {
        public virtual PdfArticle? ExecuteExtraction(PdfDocument data)
        {
            string? text = ReadText(data.Path);
            string[]? strings = text.Split(" ");
            return new PdfArticle(text.Split(" "), data.Path, DocumentTitle);
        }

        public bool TryExtract(PdfDocument input, PdfArticle? result)
        {
            try
            {
                result = ExecuteExtraction(input);
                return true;
            }
            catch
            {
                // ignored
                result = default;
                return false;
            }
        }
    }
}