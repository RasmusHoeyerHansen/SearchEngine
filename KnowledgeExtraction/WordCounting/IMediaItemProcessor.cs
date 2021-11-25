using System.Collections.Generic;
using Domain_models.Entities;
using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.WordCounting
{
    public interface IMediaItemProcessor<T> where T : IWordRatio
    {
        public IEnumerable<T> Create(ITextMediaItem item);
        public IEnumerable<T> Create(ITextMediaItem item, IMediaItemProcessingStrategy<T> strategy);
    }
}