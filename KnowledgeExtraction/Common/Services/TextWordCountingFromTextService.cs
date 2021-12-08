using System.Collections;
using System.Collections.Generic;
using System.IO;
using Domain_models.Entities;
using KnowledgeExtraction.WordCounting;
using PreProcessing.Common;
using PreProcessing.Common.Services;
using PreProcessing.Parsing.Parsers;

namespace KnowledgeExtraction.Common.Services
{
    public class TextWordCountingFromTextService : IKnowledgeFromTextService<Stream>
    {
        //Provided by preprocessing layer.
        private readonly ITextItemFactory<Stream> Factory;
        private readonly IWordCounter WordCounter;
        private IWordCountContext DatabaseAccess;

        public void ExtractKnowledge(Stream baseFormat)
        {
            ITextItem extractResult = Factory.Extract(baseFormat);
            IEnumerable<IWordCount>? WordCounts = WordCounter.CountWords(extractResult);
            //Create database objects
        }

        public TextWordCountingFromTextService(ITextItemFactory<Stream> factory,
            IWordCounter wordCounter, IWordCountContext databaseAccess)
        {
            Factory = factory;
            WordCounter = wordCounter;
            DatabaseAccess = databaseAccess;
        }
    }
}