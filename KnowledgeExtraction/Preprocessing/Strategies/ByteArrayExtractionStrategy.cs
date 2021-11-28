using System;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.Preprocessing.Strategies.Abstractions;


namespace KnowledgeExtraction.Preprocessing.Strategies
{
    internal class ByteArrayExtractionStrategy : IExtractionStrategy<byte[],PdfArticle>
    {
        public string Path { get; set; }
        

        public PdfArticle? ExecuteExtraction(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}