using System;
using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.Preprocessing
{
    public interface IPdfFactory<in TIn> : IExtractor<TIn, PdfArticle>
    {
        public PdfArticle Parse(string path);
    }
}