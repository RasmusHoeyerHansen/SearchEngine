using System;
using System.Diagnostics.CodeAnalysis;

namespace KnowledgeExtraction.Common.Exceptions
{
    public class PdfParsingException : Exception
    {
        public PdfParsingException([NotNull]string message):base($"{message}")
        {}
    }
}