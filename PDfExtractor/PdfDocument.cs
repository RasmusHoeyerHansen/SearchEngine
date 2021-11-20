﻿using iTextSharp.text;

namespace PdfExtractor
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