
using System.Collections.Generic;
using System.Linq;
using Domain_models.Entities;
using Domain_models.Models;

namespace KnowledgeExtraction.WordCounting
{
    public class WordRatioFactory : MediaItemFactory<WordRatio>
    {
        public WordRatioFactory(PdfArticle article) : base(article)
        {
        }

        public override WordRatio Create()
        {
            //Approximation of how many times words occur to initialise a good size. 
            int wordOccuranceAverage = this.Item.ParsedStrings.Count() / 3;
            List<WordRatio> occurrences = new(wordOccuranceAverage);
            List<string> Found = new(wordOccuranceAverage);
            var x = Item.ParsedStrings.Select(x => x).Count();
            

            return null;
        }

        private int CountOccurenceOfValue(List<int> list, int valueToFind)
        {
            return ((from temp in list where temp.Equals(valueToFind) select temp).Count());
        }
    }

    public abstract class MediaItemFactory<T>
    {
        protected IMediaItem Item;
        public MediaItemFactory(PdfArticle article)
        {
            Item = article;
        }

        public abstract T Create();
    }

}