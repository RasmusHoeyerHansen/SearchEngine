using System.Collections.Generic;
using Domain_models.Entities;
using KnowledgeExtraction.Common;
using KnowledgeExtraction.Common.Services;

namespace KnowledgeExtraction.WordCounting
{
    internal class WordCountingFactory :IBaseKnowledgeExtractor, IMediaItemProcessor<IWordCount>
    {
        public IEnumerable<IWordCount> ExtractKnowledge(ITextItem textItem)
        {
            return Create(textItem);
        }

        public IEnumerable<IWordCount> Create(ITextItem item)
        {
            return new DictionaryLookUpStrategy().ProcessMedia(item);
        }

        public IEnumerable<IWordCount> Create(ITextItem item, IMediaItemProcessingStrategy<IWordCount> strategy)
        {
            return strategy.ProcessMedia(item);
        }
    }
}