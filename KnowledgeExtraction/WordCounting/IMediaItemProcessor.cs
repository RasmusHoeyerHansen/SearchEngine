using System.Collections.Generic;
using Domain_models.Entities;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.WordCounting
{
    internal interface IMediaItemProcessor<T> where T : IWordRatio
    {
        public IEnumerable<T> Create(ITextMediaItem item);
        public IEnumerable<T> Create(ITextMediaItem item, IMediaItemProcessingStrategy<T> strategy);
    }
}