using System;

namespace Domain_models.Entities
{
    public class WordRatio
    {
        public string Word { get; set; }
        public int Occurances { get; set; }
        public Guid ArticleId { get; set; }
    }
}