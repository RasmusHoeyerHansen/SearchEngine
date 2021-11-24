using Domain_models.Models;

namespace Domain_models.Entities
{
    public class WordOccurance
    {
        public WordOccurance(IMediaItem article, int occurances, Word word)
        {
            Article = article;
            Occurances = occurances;
            Word = word;
        }

        public IMediaItem Article { get; set; }
        public int Occurances { get; set; }
        public Word Word { get; set; }
        
        
    }
}