
using System.Collections.Generic;
using System.Linq;
using Domain_models.Entities;
using Domain_models.Models;

namespace KnowledgeExtraction.WordCounting
{
    public class WordCounter : MediaItemDecorator<WordCountResult>
    {
        public WordCounter(PdfArticle article) : base(article)
        {
        }

        public override WordCountResult Decorate()
        {
            //Approximation of how many times words occur to initialise a good size. 
            int wordOccuranceAverage = this.Item.ParsedStrings.Count() / 3;
            List<WordCount> occurrences = new(wordOccuranceAverage);
            List<string> Found = new(wordOccuranceAverage);

            foreach (var s in Item.ParsedStrings)
            {

            }

            return null;
        }

        private int CountOccurenceOfValue(List<int> list, int valueToFind)
        {
            return ((from temp in list where temp.Equals(valueToFind) select temp).Count());
        }
    }
    

    public record WordCountResult
    {
        public IEnumerable<WordCount> Counts { get; init; }
    }

    public record WordCount()
    {
        public int Count { get; init; }
        public string Word { get; init; }
    }

    public abstract class MediaItemDecorator<T>
    {
        protected IMediaItem Item;
        public MediaItemDecorator(PdfArticle article)
        {
            Item = article;
        }

        public abstract T Decorate();
    }

}