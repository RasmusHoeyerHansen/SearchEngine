using System.Collections.Generic;
using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.WordCounting
{
    
    public interface IMediaItemProcessingStrategy<out T>
    {
        public IEnumerable<T> ProcessMedia(ITextMediaItem item);
        
    }
}