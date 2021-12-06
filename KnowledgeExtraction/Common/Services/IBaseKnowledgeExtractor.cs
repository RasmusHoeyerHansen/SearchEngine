using System.Collections.Generic;
using Domain_models.Entities;
using KnowledgeExtraction.WordCounting;

namespace KnowledgeExtraction.Common.Services
{
    public interface IBaseKnowledgeExtractor
    {
        public IEnumerable<IWordCount> ExtractKnowledge(ITextItem textItem);
    }
}