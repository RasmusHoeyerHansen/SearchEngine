using System.Collections.Generic;

namespace Domain_models.Entities
{
    public class Author
    {
        public List<Article> WrittenArticles { get; set; }
    }
}