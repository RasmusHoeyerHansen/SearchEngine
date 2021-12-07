using System.Collections;
using System.IO;
using Domain_models.Entities;
using KnowledgeExtraction.Preprocessing.Parsers;

namespace KnowledgeExtraction.Common.Services
{
    public class PdfKnowledgeExtractionService : IPreProcessingService<Stream>
    {
        private readonly ITextItemFactory<Stream> Factory;
        private readonly IBaseKnowledgeExtractor BaseKnowledgeExtractor;

        public void PreprocessKnowledge(Stream baseFormat)
        {
            ITextItem extractResult = Factory.Extract(baseFormat);
            BaseKnowledgeExtractor.ExtractKnowledge(extractResult);
        }

        public PdfKnowledgeExtractionService(ITextItemFactory<Stream> factory,
            IBaseKnowledgeExtractor baseKnowledgeExtractor)
        {
            Factory = factory;
            BaseKnowledgeExtractor = baseKnowledgeExtractor;
        }
    }
}