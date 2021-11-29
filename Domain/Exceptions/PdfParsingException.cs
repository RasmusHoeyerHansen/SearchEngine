using System;
using System.Diagnostics.CodeAnalysis;
using iTextSharp.text.pdf;

namespace Domain_models.Exceptions
{
    public class PdfParsingException : Exception
    {
        public PdfParsingException([NotNull]string message):base($"{message}")
        {
            
        }
    }
}