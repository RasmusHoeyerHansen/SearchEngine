using System;
using System.Collections.Generic;
using KnowledgeExtraction.Common;

namespace Domain_models.Entities
{
    public class Article
    {
        public Guid AuthorId { get; set; }
        public Guid Id { get; set; }
        public virtual List<OccursIn> WordOccurances { get; set; }
        public Author Author { get; set; }
    }
}