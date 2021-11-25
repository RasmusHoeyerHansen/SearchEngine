﻿using System.Collections.Generic;
using Domain_models.Entities;
using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.WordCounting
{
    public class WordRatioFactory : IMediaItemProcessor<WordRatio>
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