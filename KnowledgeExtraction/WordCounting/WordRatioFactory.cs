using System.Collections.Generic;
using Domain_models.Entities;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.WordCounting
{
    internal class WordRatioFactory : IMediaItemProcessor<WordRatio>
    {
        public IEnumerable<WordRatio> Create(ITextMediaItem item)
        {
            return new DictionaryLookUpStrategy().ProcessMedia(item);
        }

        public IEnumerable<WordRatio> Create(ITextMediaItem item, IMediaItemProcessingStrategy<WordRatio> strategy)
        {
            return strategy.ProcessMedia(item);
        }
    }
}