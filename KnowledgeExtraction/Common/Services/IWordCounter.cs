using System.Collections.Generic;
using Domain_models.Entities;
using KnowledgeExtraction.WordCounting;
using PreProcessingTest.Common;

namespace KnowledgeExtraction.Common.Services
{
    public interface IWordCounter
    {
        public IEnumerable<IWordCount> ExtractKnowledge(ITextItem textItem);
    }
}