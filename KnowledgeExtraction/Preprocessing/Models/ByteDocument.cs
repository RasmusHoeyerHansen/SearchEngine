namespace KnowledgeExtraction.Preprocessing.Models
{
    public record ByteDocument
    {
        public ByteDocument(byte[] documentBytes, string path)
        {
            this.Bytes = documentBytes;
            this.Path = path;

        }

        public byte[] Bytes { get; }

        public string Path { get; }
    }
}