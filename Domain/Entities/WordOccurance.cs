
using System;

namespace Domain_models.Entities
{
    public class WordOccurance
    {
        public Article Article { get; set; }
        public Guid ArticleId { get; set; }
        public int Occurances { get; set; }
        public Word Word { get; set; }
    }
}