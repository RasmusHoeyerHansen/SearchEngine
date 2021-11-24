using System;
using Domain_models.Models;
using KnowledgeExtraction.Preprocessing.Models;


namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public class ByteArrayExtractionStrategy : ExtractionStrategy<byte[],PdfArticle>
    {
        private readonly byte[] Bytes;
        public ByteArrayExtractionStrategy(ByteDocument document) : base(document.Bytes)
        {
            this.Path = document.Path;
            this.Bytes = document.Bytes;
        }

        public string Path { get; set; }

        protected override string ReadText()
        {
            throw new NotImplementedException();
        }

        public override PdfArticle ExecuteExtraction()
        {
            throw new NotImplementedException();
        }
    }
}