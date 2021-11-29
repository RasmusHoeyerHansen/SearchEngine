using Domain_models.Exceptions;
using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.Preprocessing
{
    public interface IPdfFactory<in TIn> : IExtractor<TIn, PdfArticle>
    {
        /// <summary>
        /// Parses a PDF file to a PdfArticle object.
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="PdfParsingException">Throws parcing exception if parsing fails.</exception>
        /// <returns></returns>
        public PdfArticle Parse(string path);
    }
}