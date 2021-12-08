using System;
using System.Diagnostics.CodeAnalysis;

namespace PreProcessingTest.Common.Exceptions
{
    public class PdfParsingException : Exception
    {
        public PdfParsingException([NotNull] string message = "Could not parse file.") : base($"{message}")
        {
        }
    }
}