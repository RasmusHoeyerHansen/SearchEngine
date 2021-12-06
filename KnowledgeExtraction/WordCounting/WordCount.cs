using System;

namespace KnowledgeExtraction.WordCounting
{
    internal class WordCount : IWordCount
    {
        public string MediaTitle { get; set; }
        public string Word { get; set; }
        public int Occurances { get; set; }

        public Guid MediaId { get; set; }
    }
}