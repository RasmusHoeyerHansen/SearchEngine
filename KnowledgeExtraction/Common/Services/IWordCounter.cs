using System.Collections.Generic;
using Domain_models.Entities;
using KnowledgeExtraction.WordCounting;
using PreProcessing.Common;

namespace KnowledgeExtraction.Common.Services
{
    public interface IWordCounter
    {
        public IEnumerable<IWordCount> CountWords(ITextItem textItem);
    }
}