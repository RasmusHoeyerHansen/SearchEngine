using System.Collections;
using System.Collections.Generic;

namespace Domain.Models
{
    public class WordOccurance
    {
        private Article Article { get; set; }
        public int Occurances { get; set; }
        public Word Word { get; set; }
    }

    public class Word
    {
        public string Literal { get; set; }
    }

    public class Article
    {
        public List<WordOccurance> WordOccurances;
        public Author Author { get; set; }
    }

    public class Author
    {
        public List<Article> WrittenArticles { get; set; }
    }
    
    
}