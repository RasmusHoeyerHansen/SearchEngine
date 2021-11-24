namespace Domain_models.Entities
{
    public class WordOccurance
    {
        private Article Article { get; set; }
        public int Occurances { get; set; }
        public Word Word { get; set; }
    }
}