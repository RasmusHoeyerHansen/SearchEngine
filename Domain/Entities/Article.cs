using System;
using System.Collections.Generic;
namespace Domain_models.Entities
{
    public class Article
    {
        public Guid AuthorId { get; set; }
        public Guid Id { get; set; }
        public List<WordOccurance> WordOccurances { get; set; }
        public Author Author { get; set; }
    }
}