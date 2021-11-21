﻿using iTextSharp.text;

namespace PDfExtractor.Models
{
    public class PdfDocument : Document
    {
        public string Path { get; }
        public PdfDocument(string path)
        {
            Path = path;
        }
    }
}