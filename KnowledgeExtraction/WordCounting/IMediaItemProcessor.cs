using System.Collections.Generic;
using Domain_models.Entities;
using KnowledgeExtraction.Common;
using PreProcessingTest.Common;

namespace KnowledgeExtraction.WordCounting
{
    internal interface IMediaItemProcessor<T> where T : IWordCount
    {
        public IEnumerable<T> Create(ITextItem item);
        public IEnumerable<T> Create(ITextItem item, IMediaItemProcessingStrategy<T> strategy);
    }
}