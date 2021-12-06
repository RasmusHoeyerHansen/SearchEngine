using System;
using System.Collections.Generic;

namespace Domain_models.Entities
{
    public class Author
    {
        public string AuthorName { get; set; }
        public virtual List<Article> WrittenArticles { get; set; }
        public string Name { get; set; }
    }
}