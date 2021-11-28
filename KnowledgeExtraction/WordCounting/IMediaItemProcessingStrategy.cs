using System.Collections.Generic;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.WordCounting
{
    internal interface IMediaItemProcessingStrategy<out T>
    {
        public IEnumerable<T> ProcessMedia(ITextMediaItem item);
        
    }
}