using System.Collections;
using System.IO;
using Domain_models.Entities;
using PreProcessingTest.Common;
using PreProcessingTest.Common.Services;
using PreProcessingTest.Parsing.Parsers;

namespace KnowledgeExtraction.Common.Services
{
    public class PdfKnowledgeExtractionService : IPreProcessingService<Stream>
    {
        private readonly ITextItemFactory<Stream> Factory;
        private readonly IWordCounter WordCounter;

        public void PreprocessKnowledge(Stream baseFormat)
        {
            ITextItem extractResult = Factory.Extract(baseFormat);
            WordCounter.ExtractKnowledge(extractResult);
        }

        public PdfKnowledgeExtractionService(ITextItemFactory<Stream> factory,
            IWordCounter wordCounter)
        {
            Factory = factory;
            WordCounter = wordCounter;
        }
    }
}