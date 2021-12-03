using System;
using System.IO;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.text.pdf.parser;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.Parsers.Strategies.Abstractions;
using PdfDocument = KnowledgeExtraction.Preprocessing.Models.PdfDocument;

namespace KnowledgeExtraction.Preprocessing.Parsers.Strategies
{
    internal class StreamExtractionStrategy : IExtractionStrategy<Stream, PdfArticle>
    {
        public PdfArticle? ExecuteExtraction(Stream data)
        {
            string title;
            StringBuilder bob = new();
            using (PdfReader reader = new(data))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    bob.Append(PdfTextExtractor.GetTextFromPage(reader, i,
                        new GlyphTextRenderListener(new LocationTextExtractionStrategy())));
                }
                title=reader.Info["Title"];
                return new PdfArticle(bob.ToString().Split(" "), title);
            }
        }
    }

    internal class PdfExtractionStrategy 
        : DocumentTextReader, ITryExtractionStrategy<PdfDocument, PdfArticle>
    {
        public virtual PdfArticle? ExecuteExtraction(PdfDocument data)
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