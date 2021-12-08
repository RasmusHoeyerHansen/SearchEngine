﻿namespace KnowledgeExtraction.Common.Services
{
    public interface IPreProcessingService<in TIn>
    {
        public void PreprocessKnowledge(TIn baseFormat);
    }
}