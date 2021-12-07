using System;

namespace Domain_models.Entities
{
    public class OccursIn
    {
        public Article Article { get; set; }
        public Guid ArticleId { get; set; }
        public Word Word { get; set; }
        public int NumberOfOccurances { get; set; }
    }
}