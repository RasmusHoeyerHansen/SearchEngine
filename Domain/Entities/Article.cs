using System;
using System.Collections.Generic;
using KnowledgeExtraction.Common;

namespace Domain_models.Entities
{
    public class Article
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public Guid Id { get; set; }
        public virtual List<OccursIn> Words { get; set; }
        public Author Author { get; set; }
    }
}