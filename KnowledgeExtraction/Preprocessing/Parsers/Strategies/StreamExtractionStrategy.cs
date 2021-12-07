using System;
using System.IO;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using KnowledgeExtraction.Common;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Preprocessing.Models;
using KnowledgeExtraction.Preprocessing.Parsers.Strategies.Abstractions;

namespace KnowledgeExtraction.Preprocessing.Parsers.Strategies
{
    internal class StreamExtractionStrategy : ITryExtractionStrategy<Stream, ITextItem>
    {
        public ITextItem? ExecuteExtraction(Stream data)
        {
            string title;
            StringBuilder bob = new();
            using (PdfReader reader = new(data))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                    bob.Append(PdfTextExtractor.GetTextFromPage(reader, i,
                        new GlyphTextRenderListener(new LocationTextExtractionStrategy())));
                title = reader.Info["Title"];
                return new PdfArticle(bob.ToString().Split(" "), title);
            }
        }

        public bool TryExtract(Stream documentStream, out ITextItem? result)
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